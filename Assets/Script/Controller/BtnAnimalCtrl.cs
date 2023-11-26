using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAnimalCtrl : BtnItembase
{
    public AnimalCtrl animalCtrl;
    public override void Initialize(PlayScreen playScreen, Item item)
    {
        base.Initialize(playScreen, item);
        button.onClick.AddListener(OnClick);
    }

    public override void OnClick()
    {
        base.OnClick();
        playScreen.SetBtnAnimals(this);
    }
}
