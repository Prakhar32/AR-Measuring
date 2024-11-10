using System.Collections;
using NUnit.Framework;
using UnityEngine;
using System;
using UnityEngine.TestTools;

public class ImperialUnitConvertorTest
{
    [Test]
    public void ConvertNegative()
    {
        Assert.Throws<ArgumentException>(() => ImperialUnitConvertor.convert(-1));
    }

    [Test]
    [TestCase(0)]
    [TestCase(10)]
    [TestCase(20)]
    public void ConvertWhenZeroFeet(float unitsInCms)
    {
        ImperialUnits units = ImperialUnitConvertor.convert(unitsInCms);
        Assert.AreEqual(unitsInCms / 2.54f, units.inches);
        Assert.AreEqual(0, units.feets);
    }

    [Test]
    public void Convert50cm()
    {
        ImperialUnits units = ImperialUnitConvertor.convert(50);
        Assert.AreEqual(8, Mathf.RoundToInt(units.inches));
        Assert.AreEqual(1, units.feets);
    }
}
