using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataItem : Singleton<DataItem>
{
    public string dataItem
    {
        get => PlayerPrefs.GetString("data_item", "");
        set => PlayerPrefs.SetString("data_item", value);
    }

    public Items items;

    public void LoadData(List<BtnItembase> itembases)
    {
        if (dataItem.Length <= 0)
        {
            items = new Items();
            for (int i = 0; i < itembases.Count; i++)
            {
                Item item = new Item(itembases[i]);
                items.listItem.Add(item);
            }
            Save();
        }
        else
        {
            items = JsonUtility.FromJson<Items>(dataItem);
        }
    }

    public void AddItemSpeeds(int id, BtnType type, int amount)
    {
        foreach (var i in items.listItem)
        {
            if (i.id == id && i.type == type)
            {
                i.amountSpeeds += amount;
                Save();
                break;
            }
        }
        GameManager.Instance.uiController.GetScreen<PlayScreen>().UpdateTxtItem();

    }

    public int GetAmountSpeeds(int id, BtnType type)
    {
        foreach (var i in items.listItem)
        {
            if (i.id == id && i.type == type)
            {
                return i.amountSpeeds;
            }
        }
        return 0;
    }

    public int GetAmountRipe(int id, BtnType type)
    {
        foreach (var i in items.listItem)
        {
            if (i.id == id && i.type == type)
            {
                return i.amountItemRipe;
            }
        }
        return 0;
    }

    public void AddAmountRipe(int id, BtnType type, int amount)
    {
        foreach (var i in items.listItem)
        {
            if (i.id == id && i.type == type)
            {
                i.amountItemRipe += amount;
                Save();
                break;
            }
        }
    }
    public void Save()
    {
        string data = JsonUtility.ToJson(items);
        dataItem = data;
    }
}

[System.Serializable]
public class Items
{
    public Items()
    {
        listItem = new List<Item>();
    }
    public List<Item> listItem;
}
[System.Serializable]
public class Item
{
    public Item(BtnItembase itembase)
    {
        this.id = itembase.id;
        this.type = itembase.type;
        amountSpeeds = 0;
        amountItemRipe = 0;
    }
    public int id;
    public BtnType type;
    public int amountSpeeds;
    public int amountItemRipe;
}