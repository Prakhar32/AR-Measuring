using System;
using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class SwitchMeasurementUnitsTest
{
    [UnityTest]
    public IEnumerator convertorMissing()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject go = new GameObject();
        SwitchMeasurementUnits switchMeasurement = go.AddComponent<SwitchMeasurementUnits>();
        yield return null;
        Assert.IsTrue(switchMeasurement == null);
    }

    [UnityTest]
    public IEnumerator dropDownMissing()
    {
        LogAssert.ignoreFailingMessages = true;
        Convertor convertor = new Convertor();
        GameObject go = new GameObject();
        SwitchMeasurementUnits switchMeasurement = go.AddComponent<SwitchMeasurementUnits>();
        switchMeasurement.SetDependancies(convertor);
        yield return null;
        Assert.IsTrue(switchMeasurement == null);
    }

    [UnityTest]
    public IEnumerator composedSuccessfully()
    {
        Convertor convertor = new Convertor();
        GameObject go = new GameObject();
        go.AddComponent<TMP_Dropdown>();
        SwitchMeasurementUnits switchMeasurement = go.AddComponent<SwitchMeasurementUnits>();
        switchMeasurement.SetDependancies(convertor);
        yield return null;
        Assert.IsTrue(switchMeasurement != null);
    }

    [UnityTest]
    public IEnumerator switchToImperialUnits()
    {
        Convertor convertor = new Convertor();
        GameObject go = new GameObject();
        TMP_Dropdown dropdown = go.AddComponent<TMP_Dropdown>();
        SwitchMeasurementUnits switchMeasurement = go.AddComponent<SwitchMeasurementUnits>();
        switchMeasurement.SetDependancies(convertor);
        yield return null;
        dropdown.onValueChanged.AddListener((value) => switchMeasurement.SwitchUnits(value));
        yield return null;
        dropdown.options.Add(new TMP_Dropdown.OptionData());
        dropdown.options.Add(new TMP_Dropdown.OptionData());
        dropdown.value = 1;
        yield return null;
        dropdown.onValueChanged.Invoke(dropdown.value);
        yield return null;

        ImperialUnitFormatter formatter = new ImperialUnitFormatter();
        Assert.AreEqual(formatter.formatUnits(100), convertor.Convert(100));
    }

    [UnityTest]
    public IEnumerator switchToMetricUnits()
    {
        Convertor convertor = new Convertor();
        GameObject go = new GameObject();
        TMP_Dropdown dropdown = go.AddComponent<TMP_Dropdown>();
        SwitchMeasurementUnits switchMeasurement = go.AddComponent<SwitchMeasurementUnits>();
        switchMeasurement.SetDependancies(convertor);
        yield return null;
        dropdown.options.Add(new TMP_Dropdown.OptionData());
        dropdown.options.Add(new TMP_Dropdown.OptionData());
        dropdown.onValueChanged.AddListener((value) => switchMeasurement.SwitchUnits(value));
        yield return null;
        dropdown.value = 0;
        dropdown.onValueChanged.Invoke(dropdown.value);
        yield return null;

        MetricUnitFormatter formatter = new MetricUnitFormatter();
        Assert.AreEqual(formatter.formatUnits(140), convertor.Convert(140));
    }
}
