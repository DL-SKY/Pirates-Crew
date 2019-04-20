using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScreenController : ScreenController
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
    #endregion

    #region Private methods
    private IEnumerator Initializing()
    {
        yield return MainGameManager.Instance.LoadSceneCoroutine(ConstantsScene.TEST);

        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        //...

        yield return SplashScreenManager.Instance.HideSplashScreen();
    }
    #endregion
}
