using System;

[Serializable]
public class ParameterData
{
    public string id;
    public float value;

    public ParameterData(EnumParameters _param, float _value)
    {
        id = _param.ToString();
        value = _value;
    }
}
