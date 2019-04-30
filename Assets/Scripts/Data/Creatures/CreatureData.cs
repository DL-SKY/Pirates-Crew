using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CreatureData
{
    #region Varialbles
    public string body;             //Название префаба туловища

    //TODO: после тестов сделать защищенными
    public List<ParameterData> parametersList = new List<ParameterData>();
    public List<string> skillsList = new List<string>();
    public List<string> inventoryList = new List<string>();

    [NonSerialized]
    protected Dictionary<EnumParameters, float> parameters = new Dictionary<EnumParameters, float>();
    [NonSerialized]
    protected Dictionary<EnumItemTypes, string> inventory = new Dictionary<EnumItemTypes, string>();
    #endregion

    #region Public methods
    public void Initialize()
    {
        UpdateParametersDictionary();
        UpdateInventoryDictionary();
    }    

    public float GetParameter(EnumParameters _param)
    {
        if (parameters.Count < 1)
            UpdateParametersDictionary();

        //TODO:
        //Добавить поиск по бонусам к параметрам в инвентаре

        if (parameters.ContainsKey(_param))
            return parameters[_param];
        else
            return 0.0f;
    }    

    public string GetItem(EnumItemTypes _type)
    {
        if (inventory.Count < 1)
            UpdateInventoryDictionary();

        if (inventory.ContainsKey(_type))
            return inventory[_type];
        else
            return "";
    }
    #endregion

    #region Protected methods
    protected void UpdateParametersDictionary()
    {
        parameters.Clear();

        foreach (var paramData in parametersList)
        {
            var key = (EnumParameters)Enum.Parse(typeof(EnumParameters), paramData.id);
            var value = paramData.value;

            parameters.Add(key, value);
        }
    }

    protected void UpdateInventoryDictionary()
    {
        inventory.Clear();

        foreach (var item in inventoryList)
        {
            //TODO:
            var itemData = item;
            var key = (EnumItemTypes)Enum.Parse(typeof(EnumItemTypes), itemData);
            var value = item;

            inventory.Add(key, value);
        }
    }
    #endregion

    #region Private methods
    #endregion
}
