using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CreatureData
{
    #region Varialbles
    public string body;

    public Dictionary<EnumParameters, float> parameters;
    #endregion

    #region Public methods
    public float GetParameter(EnumParameters _param)
    {
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
