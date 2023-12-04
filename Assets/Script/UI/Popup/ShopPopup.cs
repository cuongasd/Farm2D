using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopPopup : PopupUI
{
    public Button btnClose;
    public List<BtnItemBuy> btnItemBuys;
    public override void Initialize(UIController uiController)
    {
        base.Initialize(uiController);
        btnClose.onClick.AddListener(() => {
            AudioManager.Instance.PlayOneShot("button", 1f);
            Hide();
        });
        foreach (var i in btnItemBuys)
        {
            i.Initialize();
        }
    }
}
