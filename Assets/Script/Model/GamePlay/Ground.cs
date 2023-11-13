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
        if (cropsController != null)
        {
            this.idCrops = cropsController.id;
            this.time = cropsController.curHarvestTime;
        }
        this.empty = empty;
    }
    public int id;
    public int idCrops;
    public bool empty;
    public float time;
}
