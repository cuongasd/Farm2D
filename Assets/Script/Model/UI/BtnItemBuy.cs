using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnItemBuy : MonoBehaviour
{
    public Button btnBuy;
    public int id;
    public BtnType btnType;
    public int price;
    public Text priceTxt;
    public void Initialize()
    {
        btnBuy.onClick.AddListener(OnBuy);
        priceTxt.text = $"{price}";
    }

    public void OnBuy()
    {
        AudioManager.Instance.PlayOneShot("button", 1f);
        if (DataPlayer.Instance.player.coins >= price)
        {
            DataItem.Instance.AddItemSpeeds(id, btnType, 1);
            DataPlayer.Instance.AddCoin(-price);
        }
    }
}
