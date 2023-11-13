using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCtrl : ItemBase
{
    public int id;
    public CropsController cropsController;
    public bool empty;
    public override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        if (empty) return;
        BtnCropsCtrl btnCropsCtrl = GameManager.Instance.uiController.GetScreen<PlayScreen>().btnCropsCtrl;
        if (btnCropsCtrl != null)
        {
            cropsController = Instantiate(btnCropsCtrl.cropsController, transform.position, Quaternion.Euler(0, 0, 0), GameManager.Instance.itemHolder);
            cropsController.Initialize();
            empty = true;
            DataMap.Instance.SetGround(this);
        }
    }

    public void SetInfoGround(Ground ground)
    {
        id = ground.id;
        if (ground.empty)
        {
            cropsController = Instantiate(Resources.Load<CropsController>("Crops_" + ground.idCrops), transform.position, Quaternion.Euler(0, 0, 0), GameManager.Instance.itemHolder);
            cropsController.Initialize();
            cropsController.curHarvestTime = ground.time;
        }

    }
}
