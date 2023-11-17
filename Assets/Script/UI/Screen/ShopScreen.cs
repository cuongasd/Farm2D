using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScreen : PopupUI
{
    public Button btnClose;
    public void Initialize()
    {
        btnClose.onClick.AddListener(Hide);
    }
}
