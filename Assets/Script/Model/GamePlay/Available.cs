using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataAvailable
{
    public DataAvailable()
    {
        availables = new List<Available>();
    }
    public List<Available> availables;
}
[System.Serializable]
public class Available
{
    public Available(int id)
    {
        this.id = id;
        isExist = true;
    }
    public int id;
    public bool isExist;
}
