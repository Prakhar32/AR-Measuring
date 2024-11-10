using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.XR.ARFoundation;

public class EvenTouchStateTest
{
    [UnityTest]
    public IEnumerator SecondObjectSpawned()
    {
        GameObject g = new GameObject("State Machine");
        g.SetActive(false);
        TouchStateMachine machine = g.AddComponent<TouchStateMachine>();
        machine.SetDependencies(new Convertor(), g.AddComponent<ARRaycastManager>(), new GameObject("Point"));
        g.SetActive(true);
        yield return null;
        Pose pose = new Pose();
        machine.getOddTouchState().Touched(pose);
        yield return null;
        machine.getEvenTouchState().Touched(pose);
        yield return null;
        Assert.IsNotNull(machine.getAssociatedPair());
    }
}
