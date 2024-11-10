using NUnit.Framework;
using System;

public class MetricUnitsFormatterTest
{
    [Test]
    public void NegativeFormat()
    {
        Formatter formatter = new MetricUnitFormatter();
        Assert.Throws<ArgumentException>(() => formatter.formatUnits(-1));
    }

    [Test]
    [TestCase(40)]
    [TestCase(90)]
    [TestCase(140)]
    [TestCase(240)]
    public void Format(float valueInCMs)
    {
        Formatter formatter = new MetricUnitFormatter();
        string formattedUnits = formatter.formatUnits(valueInCMs);
        Assert.AreEqual(string.Format("{0} m {1} cms", (int)(valueInCMs / 100), (int)(valueInCMs % 100)), formattedUnits);
    }
}
