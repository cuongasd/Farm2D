using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMap : Singleton<DataMap>
{
    private string dataMap
    {
        get => PlayerPrefs.GetString("data_map", "");
        set => PlayerPrefs.SetString("data_map", value);
    }

    public DataGround dataGround;
    public List<GroundCtrl> groundCtrls;
    public void LoadData()
    {
        if (dataMap.Length > 0)
        {
            dataGround = JsonUtility.FromJson<DataGround>(dataMap);
        }
        else
        {
            dataGround.grounds = new List<Ground>();
            for (int i = 0; i < groundCtrls.Count; i++)
            {
                Ground g = new Ground(i, groundCtrls[i].cropsController, groundCtrls[i].empty);
                dataGround.grounds.Add(g);
            }
        }

        for (int i = 0; i < dataGround.grounds.Count; i++)
        {
            groundCtrls[i].SetInfoGround(dataGround.grounds[i]);
        }
    }
    public void Save()
    {
        string data = JsonUtility.ToJson(dataGround);
        dataMap = data;
    }

    public void SaveGround()
    {
    }

    public void SetGround(GroundCtrl groundCtrl)
    {
        foreach (Ground i in dataGround.grounds)
        {
            if (i.id == groundCtrl.id)
            {
                i.empty = groundCtrl.empty;
                i.idCrops = groundCtrl.cropsController.id;
                i.time = groundCtrl.cropsController.curHarvestTime;
                break;
            }
        }
        Save();
    }
}
