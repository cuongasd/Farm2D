using System.Collections.Generic;
[System.Serializable]
public class DataGround 
{
    public List<Ground> grounds;
}

[System.Serializable]
public class Ground
{
    public Ground(int id, CropsController cropsController, bool empty)
    {
        this.id = id;
        this.cropsController = cropsController;
        this.empty = empty;
    }
    public int id;
    public CropsController cropsController;
    public bool empty;
}
