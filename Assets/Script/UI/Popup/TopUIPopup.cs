using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TopUIPopup : PopupUI
{
    public Text levelTxt;
    public Text coinTxt;
    public override void Initialize(UIController uiController)
    {
        base.Initialize(uiController);
        UpdateTxt();
    }

    public void UpdateTxt()
    {
        int lv = (int)(Mathf.Sqrt(8 * (DataPlayer.Instance.player.exp - 100) / 100 + 1) - 1) / 2 + 1;
        levelTxt.text = $"{lv}";
        coinTxt.text = $"{DataPlayer.Instance.player.coins}";
    }
}
