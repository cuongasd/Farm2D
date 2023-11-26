using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCropsCtrl : BtnItembase
{
    public CropsController cropsController;
    public override void Initialize(PlayScreen playScreen, Item item)
    {
        base.Initialize(playScreen, item);
        button.onClick.AddListener(OnClick);
    }

    public override void OnClick()
    {
        base.OnClick();
        playScreen.SetBtnCrop(this);
    }
}
