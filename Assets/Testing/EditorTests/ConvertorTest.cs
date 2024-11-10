using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ConvertorTest
{
    [Test]
    public void imperialUnitsConversion()
    {
        Convertor convertor = new Convertor();
        convertor.ImperialUnitSelected();
        string actual = convertor.Convert(100);
        ImperialUnitFormatter formatter = new ImperialUnitFormatter();
        string expected = formatter.formatUnits(100);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void metricUnitsConversion()
    {
        Convertor convertor = new Convertor();
        convertor.MetricUnitSelected();
        string actual = convertor.Convert(210);
        MetricUnitFormatter formatter = new MetricUnitFormatter();
        string expected = formatter.formatUnits(210);
        Assert.AreEqual(expected, actual);
    }
}
