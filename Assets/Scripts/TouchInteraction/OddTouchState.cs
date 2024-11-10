using UnityEngine;

public class OddTouchState : TouchState
{
    private GameObject _prefab;
    private TouchStateMachine stateMachine;

    public OddTouchState(GameObject prefab, TouchStateMachine stateMachine)
    {
        _prefab = prefab;
        this.stateMachine = stateMachine;
    }

    public void Touched(Pose pose)
    {
        GameObject point = GameObject.Instantiate(_prefab);
        point.transform.localPosition = pose.position;
        point.transform.localRotation = pose.rotation;
        stateMachine.CreateNewPair();
        stateMachine.getAssociatedPair().FirstOfPairSet(point);
        stateMachine.SetTouchState(stateMachine.getEvenTouchState());
    }
}
