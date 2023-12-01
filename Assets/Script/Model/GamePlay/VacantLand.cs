using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacantLand : ItemBase
{
    public int id;
    public AnimalCtrl animalCtrl;
    public bool empty;
    public override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        if (!empty)
        {
            BtnAnimalCtrl btnAnimalCtrl = GameManager.Instance.uiController.GetScreen<PlayScreen>().btnAnimalCtrl;
            Vector3 pos = new Vector3(transform.position.x, 0.18f, transform.position.z);
            if (btnAnimalCtrl != null && DataItem.Instance.GetAmountSpeeds(btnAnimalCtrl.animalCtrl.id, BtnType.ANIMAL) > 0)
            {
                animalCtrl = Instantiate(btnAnimalCtrl.animalCtrl, pos, Quaternion.Euler(0, Random.Range(0, 360), 0), GameManager.Instance.itemHolder);
                animalCtrl.Initialize();
                empty = true;
                DataMap.Instance.SetVacantLand(this);
                DataItem.Instance.AddItemSpeeds(animalCtrl.id, BtnType.ANIMAL, -1);
            }
        }
        else
        {
            if (animalCtrl.isRipe)
            {
                DataItem.Instance.AddAmountRipe(animalCtrl.id, BtnType.ANIMAL, 1);
                DataPlayer.Instance.AddExp(animalCtrl.exp);
                Destroy(animalCtrl.gameObject);
                animalCtrl = null;
                empty = false;
                DataMap.Instance.SetVacantLand(this);
            }
        }
    }

    public void SetInfoVacantLand(Ground ground, int id)
    {
        this.id = id;
        Vector3 pos = new Vector3(transform.position.x, 0.18f, transform.position.z);
        if (ground.empty)
        {
            animalCtrl = Instantiate(Resources.Load<AnimalCtrl>("Animal_" + ground.idAnimals), pos, Quaternion.Euler(0, Random.Range(0, 360), 0), GameManager.Instance.itemHolder);
            animalCtrl.Initialize();
            animalCtrl.curHarvestTime = ground.time;
            empty = true;
        }

    }
}
