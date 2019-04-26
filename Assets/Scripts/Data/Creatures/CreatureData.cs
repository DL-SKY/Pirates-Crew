using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CreatureData
{
    #region Varialbles
    public string body;             //Название префаба туловища


    public List<ParameterData> parametersList = new List<ParameterData>();

    [NonSerialized]
    protected Dictionary<EnumParameters, float> parameters = new Dictionary<EnumParameters, float>();
    #endregion

    #region Public methods
    public void UpdateParametersDictionary()
    {
        parameters.Clear();

        foreach (var paramData in parametersList)
        {
            var key = (EnumParameters)Enum.Parse(typeof(EnumParameters), paramData.id);
            var value = paramData.value;

            parameters.Add(key, value);
        }
    }

    public float GetParameter(EnumParameters _param)
    {
        if (parameters.Count < 1)
            UpdateParametersDictionary();

        if (parameters.ContainsKey(_param))
            return parameters[_param];
        else
            return 0.0f;
    }
    #endregion

    #region Protected methods
    #endregion

    #region Private methods
    #endregion
}
