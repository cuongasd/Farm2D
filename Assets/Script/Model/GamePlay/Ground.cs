using System.Collections.Generic;
[System.Serializable]
public class DataGround
{
    public List<Ground> grounds;
}

[System.Serializable]
public class Ground
{
    public Ground(int id, CropsController cropsController, AnimalCtrl animalCtrl, bool empty)
    {
        this.id = id;
        if (cropsController != null)
        {
            this.idCrops = cropsController.id;
            this.time = cropsController.curHarvestTime;
        } else if (animalCtrl != null)
        {
            this.idAnimals = animalCtrl.id;
            this.time = animalCtrl.curHarvestTime;
        }
        this.empty = empty;
    }
    public int id;
    public int idCrops;
    public int idAnimals;
    public bool empty;
    public float time;
}
