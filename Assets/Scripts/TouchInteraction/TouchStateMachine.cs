using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class TouchStateMachine : MonoBehaviour 
{
    private ARRaycastManager _raycastManager;
    private GameObject _pointPrefab;

    private Convertor _convertor; 
    
    private TouchState currentState;
    private TouchState oddTouchState;
    private TouchState evenTouchState;

    private AssociatedPair _pair;

    private List<ARRaycastHit> _hits;

    public void SetDependencies(Convertor convertor, ARRaycastManager raycastManager, GameObject pointPrefab) 
    {   
        if(convertor == null)
            throw new ArgumentNullException("Convertor is null");
        if (raycastManager == null)
            throw new ArgumentNullException("ARRaycastManager is null");
        if (pointPrefab == null)
            throw new ArgumentNullException("Point prefab is null");

        _convertor = convertor; 
        _raycastManager = raycastManager;
        _pointPrefab = pointPrefab;
    }

    private void Awake()
    {
        oddTouchState = new OddTouchState(_pointPrefab, this);
        evenTouchState = new EvenTouchState(_pointPrefab, this);
        currentState = oddTouchState;
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void Start()
    {
        if(_raycastManager == null)
        {
            Destroy(gameObject);
            throw new MissingComponentException("ARRaycastManager missing");
        }

        if(_convertor == null)
        {
            Destroy(gameObject);
            throw new MissingReferenceException("Convertor Missing");
        }

        if(_pointPrefab == null)
        {
            Destroy(gameObject);
            throw new MissingComponentException("Prefab missing");
        }

        _hits = new List<ARRaycastHit>();
    }

    public TouchState getOddTouchState() { return oddTouchState; }
    public TouchState getEvenTouchState() {return evenTouchState; }
    public void SetTouchState(TouchState state) 
    {
        if(state == null)
            throw new NullReferenceException("State is Null");
        currentState = state; 
    }

    public AssociatedPair getAssociatedPair() { return _pair; }
    public void CreateNewPair() 
    {
        GameObject g = new GameObject("Pair");
        _pair = g.AddComponent<AssociatedPair>();
        _pair.SetConvertor(_convertor);
    }

    private void FingerDown(Finger finger)
    {
        if (finger.index != 0)
            return;

        if (_raycastManager.Raycast(finger.currentTouch.screenPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = _hits[0].pose;
            currentState.Touched(hitPose);
        }
    }

    //private void Update()
    //{
    //    if (Input.touchCount == 0)
    //        return;
    //    if (_raycastManager.Raycast(Input.GetTouch(0).position, _hits, TrackableType.PlaneWithinPolygon))
    //    {
    //        Pose hitPose = _hits[0].pose;
    //        currentState.Touched(hitPose);
    //    }

    //    //if (Mouse.current.leftButton.wasPressedThisFrame)
    //    //{
    //    //    if (_raycastManager.Raycast(Mouse.current.position.ReadValue(), _hits, TrackableType.PlaneWithinPolygon))
    //    //    {
    //    //        Pose hitPose = _hits[0].pose;
    //    //        currentState.Touched(hitPose);
    //    //    }
    //    //}
    //}
}
