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

    [Header("Status")]
    [SerializeField]
    protected EnumDirection direction;

    [Header("Actions")]
    [SerializeField]
    protected Vector2 waypoint;

    protected CreatureData data;
    protected Rigidbody2D rb2d;
    #endregion

    #region Properties    
    public Vector2 Waypoint
    {
        get { return waypoint; }
        set { waypoint = value; ApplyWaypoint(); }
    }
    #endregion

    #region Unity methods
    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        if (Mathf.Abs(rb2d.position.x - waypoint.x) <= float.Epsilon)
            return;

        //Просчет перемещения
        var step = data.GetParameter(EnumParameters.Speed) * Time.fixedDeltaTime;
        var newPos = Vector2.MoveTowards(rb2d.position, new Vector2(waypoint.x, rb2d.position.y), step);

        //Просчет направления
        var dir = newPos.x < rb2d.position.x ? EnumDirection.Left : EnumDirection.Right;
        ApplyDirection(dir);

        //Применение перемещения
        rb2d.MovePosition(newPos);
    }

    protected virtual void Update()
    {

    }
    #endregion

    #region Public methods
    public virtual void Initialize(CreatureData _data)
    {
        data = _data;
        data.UpdateParametersDictionary();

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

        //Направление по умолчанию        
        ApplyDirection(EnumDirection.Left);
    }

    protected virtual void ApplyDirection(EnumDirection _dir)
    {
        if (_dir == direction)
            return;

        direction = _dir;

        var scale = 1.0f;

        switch (direction)
        {
            case EnumDirection.Left:
                scale = 1.0f;
                break;
            case EnumDirection.Right:
                scale = -1.0f;
                break;
        }

        transform.localScale = new Vector3(1.0f, scale, 1.0f);
    }
    #endregion

    #region Coroutines
    #endregion
}
