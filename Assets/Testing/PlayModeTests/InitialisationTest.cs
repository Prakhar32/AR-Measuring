using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.XR.ARFoundation;

public class InitialisationTest
{
    [UnityTest]
    public IEnumerator InitialisedSuccessfully()
    {
        GameObject g = new GameObject("Initialiser");
        g.SetActive(false);
        GameObject other = new GameObject("Other");
        other.SetActive(false);
        Initialisation initialisation = g.AddComponent<Initialisation>();
        initialisation.RaycastManager = other.AddComponent<ARRaycastManager>();
        other.AddComponent<TMP_Dropdown>();
        initialisation.pointPrefab = new GameObject("Point");
        initialisation.TouchStateMachine = g.AddComponent<TouchStateMachine>();
        initialisation.SwitchMeasurementUnits = other.AddComponent<SwitchMeasurementUnits>();
        yield return null;
        g.SetActive(true);
        other.SetActive(true);
        yield return null;
        
        Assert.IsTrue(initialisation.TouchStateMachine != null);
        Assert.IsTrue(initialisation.SwitchMeasurementUnits != null);
    }
}
