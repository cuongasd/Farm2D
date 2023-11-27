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
        if (empty) return;
        BtnAnimalCtrl btnAnimalCtrl = GameManager.Instance.uiController.GetScreen<PlayScreen>().btnAnimalCtrl;
        if (animalCtrl != null)
        {

        }

        if (!empty)
        {
            BtnCropsCtrl btnCropsCtrl = GameManager.Instance.uiController.GetScreen<PlayScreen>().btnCropsCtrl;
            if (btnCropsCtrl != null && DataItem.Instance.GetAmountSpeeds(btnCropsCtrl.cropsController.id, BtnType.CROPS) > 0)
            {
                animalCtrl = Instantiate(btnAnimalCtrl.animalCtrl, transform.position, Quaternion.Euler(0, 0, 0), GameManager.Instance.itemHolder);
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

}
