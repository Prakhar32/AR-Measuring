using UnityEngine;

public class EvenTouchState : TouchState
{
    private GameObject _prefab;
    private TouchStateMachine stateMachine;

    public EvenTouchState(GameObject prefab, TouchStateMachine stateMachine)
    {
        _prefab = prefab;
        this.stateMachine = stateMachine;
    }

    public void Touched(Pose pose)
    {
        GameObject point = GameObject.Instantiate(_prefab);
        point.transform.localPosition = pose.position;
        point.transform.localRotation = pose.rotation;
        Debug.Log(stateMachine.getAssociatedPair() == null);
        stateMachine.getAssociatedPair().SecondOfPairSet(point, pose.up);
        stateMachine.SetTouchState(stateMachine.getOddTouchState());
    }
}
