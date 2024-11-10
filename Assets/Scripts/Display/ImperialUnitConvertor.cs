using System;
using UnityEngine;

public class ImperialUnitConvertor
{
    public static ImperialUnits convert(float metricUnitInCms)
    {
        if (metricUnitInCms < 0)
            throw new ArgumentException("Cannot convert negative units");

        ImperialUnits units = new ImperialUnits();
        float inches = metricUnitInCms / 2.54f;
        units.feets = (int)(inches / 12f);
        units.inches = inches % 12;
        return units;
    }
}
