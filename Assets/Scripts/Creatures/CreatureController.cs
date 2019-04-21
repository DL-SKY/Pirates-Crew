using DllSky.Extensions;
using DllSky.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    #region Variables
    [Header("Links")]
    public Animator animator;
    public Transform tBody;

    [SerializeField]
    [Header("Folders")]
    protected string creaturePrefFolder;

    [Header("Actions")]
    public Vector2 movePoint;

    protected CreatureData data;
    #endregion

    #region Unity methods
    #endregion

    #region Public methods
    public virtual void Initialize(CreatureData _data)
    {
        data = _data;

        LoadBody();
    }
    #endregion

    #region Protected methods
    protected virtual void LoadBody()
    {
        tBody.DestroyChildren();

        var folder = string.Format(@"{0}{1}/{2}/", ConstantsResourcesPath.CREATURES, creaturePrefFolder, "Body");
        var prefab = ResourcesManager.LoadPrefab(folder, data.body);

        Instantiate(prefab, tBody);
    }
    #endregion

    #region Private methods
    #endregion

    #region Coroutines
    #endregion
}
