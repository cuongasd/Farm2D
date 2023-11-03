using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacantLand : ItemBase
{
    private AnimalCtrl animalCtrl;
    private bool empty;
    public override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        if (empty) return;
        BtnAnimalCtrl btnAnimalCtrl = GameManager.Instance.uiController.GetScreen<PlayScreen>().btnAnimalCtrl;
        if (animalCtrl != null)
        {
            animalCtrl = Instantiate(btnAnimalCtrl.animalCtrl, transform.position, Quaternion.Euler(0, 0, 0), GameManager.Instance.itemHolder);
            animalCtrl.Initialize();
            empty = true;
        }
    }
}
