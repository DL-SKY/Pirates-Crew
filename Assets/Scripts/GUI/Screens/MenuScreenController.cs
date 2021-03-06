﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenController : ScreenController
{
    #region Variables
    #endregion

    #region Unity methods
    private void OnEnable()
    {
        if (IsInit)
            StartCoroutine(Initializing());
    }
    #endregion

    #region Public methods
    public override void Initialize(object _data)
    {
        base.Initialize(_data);

        StartCoroutine(Initializing());
    }

    public void OnClickTest()
    {
        StartCoroutine(GoToTestScene());
    }
    #endregion

    #region Private methods
    private IEnumerator Initializing()
    {
        yield return MainGameManager.Instance.LoadSceneCoroutine(ConstantsScene.MENU);

        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        //...

        yield return SplashScreenManager.Instance.HideSplashScreen();
    }

    private IEnumerator GoToTestScene()
    {
        yield return SplashScreenManager.Instance.ShowBlack();

        ScreenManager.Instance.ShowScreen(ConstantsScreen.TEST);
    }
    #endregion
}
