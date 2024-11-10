public class Convertor
{
    private ImperialUnitFormatter _imperialUnitFormatter;
    private MetricUnitFormatter _metricUnitFormatter;

    private Formatter _formatter;

    public Convertor()
    {
        _imperialUnitFormatter = new ImperialUnitFormatter();
        _metricUnitFormatter = new MetricUnitFormatter();
        _formatter = _metricUnitFormatter;
    }

    public void ImperialUnitSelected()
    {
        _formatter = _imperialUnitFormatter;
    }

    public void MetricUnitSelected()
    {
        _formatter = _metricUnitFormatter;
    }

    public string Convert(float unit)
    {
        return _formatter.formatUnits(unit);
    }
}
