using DllSky.Utility;
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

    public void OnClickTest()
    {
        var human = Instantiate(ResourcesManager.LoadPrefab(ConstantsResourcesPath.PREFABS, ConstantsPrefabName.CREATURE_HUMAN), Vector3.zero, Quaternion.identity).GetComponent<HumanController>();

        //Test data's
        var data = new HumanData();
        data.body = "human_01";
        data.parametersList.Add(new ParameterData(EnumParameters.Speed, 1.5f));

        human.Initialize(data);
        human.gameObject.AddComponent<CreatureInputPlayer>();
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
