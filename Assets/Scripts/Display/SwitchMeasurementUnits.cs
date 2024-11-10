using UnityEngine;
using TMPro;

public class SwitchMeasurementUnits : MonoBehaviour
{
    private Convertor _convertor;
    private TMP_Dropdown _dropdown;

    public void SetDependancies(Convertor convertor) {  this._convertor = convertor; }

    void Start()
    {
        if (_convertor == null)
        {
            Destroy(this);
            throw new MissingReferenceException("Converter not set");
        }

        if (GetComponent<TMP_Dropdown>() == null)
        {
            Destroy(this);
            throw new MissingReferenceException("DropDwon Missing");
        }
        else
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _dropdown.onValueChanged.AddListener((value) => SwitchUnits(value));
        }
    }

    public void SwitchUnits(int value)
    {
        if (value == 0)
            _convertor.MetricUnitSelected();
        if (value == 1)
            _convertor.ImperialUnitSelected();
    }
}
