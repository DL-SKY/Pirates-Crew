using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : CreatureController
{
    #region Variables
    [Header("Links")]
    public Transform tFace;
    public Transform tWeaponMelee;
    public Transform tWeaponRange;
    public Transform tHelmet;
    public Transform tClothes;
    public Transform tAccessory;
    #endregion

    #region Unity methods
    #endregion

    #region Public methods
    public override void Initialize(CreatureData _data)
    {
        base.Initialize(_data);
    }
    #endregion

    #region Protected methods
    #endregion

    #region Private methods
    #endregion

    #region Coroutines
    #endregion
}
