using NUnit.Framework;
using System;

public class ImperialUnitFormatterTest
{
    [Test]
    public void NegativeNumberFormat()
    {
        Formatter formatter = new ImperialUnitFormatter();
        Assert.Throws<ArgumentException>(() => formatter.formatUnits(-1));
    }

    [Test]
    [TestCase(0)]
    [TestCase(30)]
    [TestCase(100)]
    [TestCase(200)]
    public void format(float unitInCms)
    {
        Formatter formatter = new ImperialUnitFormatter();
        ImperialUnits units = ImperialUnitConvertor.convert(unitInCms);
        string expected = string.Format("{0} ft {1} inches", units.feets, units.inches.ToString("F1"));
        Assert.AreEqual(expected, formatter.formatUnits(unitInCms));
    }
}
