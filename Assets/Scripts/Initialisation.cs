using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Initialisation : MonoBehaviour
{
    public TouchStateMachine TouchStateMachine;
    public SwitchMeasurementUnits SwitchMeasurementUnits;
    public ARRaycastManager RaycastManager;
    public GameObject pointPrefab;

    void Awake()
    {
        Convertor convertor = new Convertor();
        TouchStateMachine.SetDependencies(convertor, RaycastManager, pointPrefab);
        TouchStateMachine.gameObject.SetActive(true);
        SwitchMeasurementUnits.SetDependancies(convertor);
    }
}
