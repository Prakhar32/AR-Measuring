using System;

public class ImperialUnitFormatter : Formatter
{
    public string formatUnits(float metricUnits)
    {
        ImperialUnits units = ImperialUnitConvertor.convert(metricUnits);
        string formattedUnits = string.Format("{0} ft {1} inches", units.feets, units.inches.ToString("F1"));
        return formattedUnits;
    }
}
