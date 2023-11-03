using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAnimalCtrl : BtnItembase
{
    public AnimalCtrl animalCtrl;
    public override void Initialize(PlayScreen playScreen)
    {
        base.Initialize(playScreen);
        button.onClick.AddListener(OnClick);
    }

    public override void OnClick()
    {
        base.OnClick();
        playScreen.SetBtnAnimals(this);
    }
}
