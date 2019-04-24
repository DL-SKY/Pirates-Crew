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
    [SerializeField]
    protected Vector2 waypoint;

    protected CreatureData data;
    #endregion

    #region Properties    
    public Vector2 Waypoint
    {
        get { return waypoint; }
        set { waypoint = value; ApplyWaypoint(); }
    }
    #endregion

    #region Unity methods
    protected virtual void FixedUpdate()
    {
        
    }

    protected virtual void Update()
    {

    }
    #endregion

    #region Public methods
    public virtual void Initialize(CreatureData _data)
    {
        data = _data;

        LoadBody();
    }
    #endregion

    #region Properties methods
    protected virtual void ApplyWaypoint()
    {
        //TODO
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
