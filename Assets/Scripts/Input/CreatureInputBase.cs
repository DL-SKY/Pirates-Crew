using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureInputBase : MonoBehaviour
{
    #region Variables
    protected CreatureController creature;
    #endregion

    #region Unity methods
    protected virtual void Awake()
    {
        creature = GetComponent<CreatureController>();
    }
    #endregion

    #region Public methods
    #endregion

    #region Protected methods
    #endregion

    #region Private methods
    #endregion
}
