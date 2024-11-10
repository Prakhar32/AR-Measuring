
using System;

public class MetricUnitFormatter : Formatter
{
    public string formatUnits(float metricUnits)
    {
        if (metricUnits < 0)
            throw new ArgumentException("Cannot format negativve units");
        return string.Format("{0} m {1} cms", (int)(metricUnits / 100), (int)(metricUnits % 100));
    }
}
