using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.XR.ARFoundation;

public class TouchStateMachineTest
{
    [UnityTest]
    public IEnumerator DependenciesMissing()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        TouchStateMachine machine = g.AddComponent<TouchStateMachine>();
        yield return null;
        Assert.IsTrue(machine == null);
    }

    [UnityTest]
    public IEnumerator convertorNull()
    {
        LogAssert.ignoreFailingMessages = true;
        Convertor convertor = new Convertor();
        GameObject g = new GameObject();
        TouchStateMachine machine = g.AddComponent<TouchStateMachine>();
        Assert.Throws<ArgumentNullException>(() => machine.SetDependencies(null, g.AddComponent<ARRaycastManager>(), new GameObject("Point")));
        yield return null;
    }

    [UnityTest]
    public IEnumerator RayCastManagerNull()
    {
        LogAssert.ignoreFailingMessages = true;
        Convertor convertor = new Convertor();
        GameObject g = new GameObject();
        TouchStateMachine machine = g.AddComponent<TouchStateMachine>();
        Assert.Throws<ArgumentNullException> (() =>machine.SetDependencies(convertor, null, new GameObject("Point")));
        yield return null;
    }

    [UnityTest]
    public IEnumerator PrefabNull()
    {
        LogAssert.ignoreFailingMessages = true;
        Convertor convertor = new Convertor();
        GameObject g = new GameObject();
        TouchStateMachine machine = g.AddComponent<TouchStateMachine>();
        Assert.Throws<ArgumentNullException>(() => machine.SetDependencies(convertor, g.AddComponent<ARRaycastManager>(), null));
        yield return null;
    }

    [UnityTest]
    public IEnumerator composedSuccessfully()
    {
        Convertor convertor = new Convertor();
        GameObject g = new GameObject();
        TouchStateMachine machine = g.AddComponent<TouchStateMachine>();
        machine.SetDependencies(convertor, g.AddComponent<ARRaycastManager>(), new GameObject("Point"));
        yield return null;
        Assert.IsTrue(machine != null);
    }
}
