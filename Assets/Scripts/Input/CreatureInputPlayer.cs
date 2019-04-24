using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureInputPlayer : CreatureInputBase
{
    #region Variables
    #endregion

    #region Unity methods
    private void OnEnable()
    {
        LeanTouch.OnFingerTap += OnFingerTapHandler;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= OnFingerTapHandler;
    }
    #endregion

    #region Public methods
    #endregion

    #region Protected methods
    #endregion

    #region Private methods
    private void OnFingerTapHandler(LeanFinger _finger)
    {
        if (creature == null || _finger.StartedOverGui)
            return;

        SetWaypoint(Camera.main.ScreenToWorldPoint(_finger.ScreenPosition));
    }
    #endregion
}
