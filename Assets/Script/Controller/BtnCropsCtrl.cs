using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCropsCtrl : BtnItembase
{
    public CropsController cropsController;
    public override void Initialize(PlayScreen playScreen)
    {
        base.Initialize(playScreen);
        button.onClick.AddListener(OnClick);
    }

    public override void OnClick()
    {
        base.OnClick();
        playScreen.SetBtnCrop(this);
    }
}
