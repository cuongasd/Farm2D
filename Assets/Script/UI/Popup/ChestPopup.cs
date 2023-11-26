using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestPopup : PopupUI
{
    public Button btnClose;
    public List<BtnItemChest> BtnItemChest;

    public override void Show(Action onClose)
    {
        base.Show(onClose);
        foreach (var i in BtnItemChest)
        {
            i.SetTxt(0, 0);
        }
    }
    public override void Initialize(UIController uiController)
    {
        base.Initialize(uiController);
        btnClose.onClick.AddListener(Hide);
        foreach (var i in BtnItemChest)
        {
            i.Initialize();
        }
    }
}
