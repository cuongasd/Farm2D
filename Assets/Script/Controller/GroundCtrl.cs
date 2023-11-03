using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCtrl : ItemBase
{
    private CropsController cropsController;
    private bool empty;
    public override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        if (empty) return;
        BtnCropsCtrl btnCropsCtrl = GameManager.Instance.uiController.GetScreen<PlayScreen>().btnCropsCtrl;
        if (btnCropsCtrl != null)
        {
            cropsController = Instantiate(btnCropsCtrl.cropsController, transform.position, Quaternion.Euler(0, 0, 0),GameManager.Instance.itemHolder);
            cropsController.Initialize();
            empty = true;
        }
    }
}
