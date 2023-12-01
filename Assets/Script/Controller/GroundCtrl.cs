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
        if (!empty)
        {
            BtnCropsCtrl btnCropsCtrl = GameManager.Instance.uiController.GetScreen<PlayScreen>().btnCropsCtrl;
            if (btnCropsCtrl != null && DataItem.Instance.GetAmountSpeeds(btnCropsCtrl.cropsController.id, BtnType.CROPS) > 0)
            {
                cropsController = Instantiate(btnCropsCtrl.cropsController, transform.position, Quaternion.Euler(0, 0, 0), GameManager.Instance.itemHolder);
                cropsController.Initialize();
                empty = true;
                DataMap.Instance.SetGround(this);
                DataItem.Instance.AddItemSpeeds(cropsController.id, BtnType.CROPS, -1);
            }
        }
        else
        {
            if (cropsController.isRipe)
            {
                DataItem.Instance.AddAmountRipe(cropsController.id, BtnType.CROPS, 1);
                DataPlayer.Instance.AddExp(cropsController.exp);
                Destroy(cropsController.gameObject);
                cropsController = null;
                empty = false;
                DataMap.Instance.SetGround(this);
            }
        }
    }

    public void SetInfoGround(Ground ground, int id)
    {
        this.id = id;
        if (ground.empty)
        {
            cropsController = Instantiate(Resources.Load<CropsController>("Crops_" + ground.idCrops), transform.position, Quaternion.Euler(0, 0, 0), GameManager.Instance.itemHolder);
            cropsController.Initialize();
            cropsController.curHarvestTime = ground.time;
            empty = true;
        }

    }
}
