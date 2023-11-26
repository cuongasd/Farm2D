using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnItemChest : MonoBehaviour
{
    public int id;
    public int amount;
    public int sellAmount;
    public int totalPrice;
    public int price;
    public BtnType btnType;

    [Header("UI")]
    public Button btnSell;
    public Text amountTxt;
    public Text amountSellTxt;
    public Text ttPriceTxt;
    public Button btnUp;
    public Button btnDown;
    public void Initialize()
    {
        btnSell.onClick.AddListener(OnSell);
        btnUp.onClick.AddListener(OnUpBtn);
        btnDown.onClick.AddListener(OnDownBtn);
    }

    public void OnSell()
    {
        DataItem.Instance.AddAmountRipe(id, btnType, -sellAmount);
        DataPlayer.Instance.AddCoin(totalPrice);
        SetTxt(0, 0);

    }

    public void OnUpBtn()
    {
        if (sellAmount < DataItem.Instance.GetAmountRipe(id, btnType))
        {
            sellAmount++;
            totalPrice = (sellAmount * price);
            SetTxt(sellAmount, totalPrice);
        }
    }

    public void OnDownBtn()
    {
        if (sellAmount > 0)
        {
            sellAmount--;
            totalPrice = sellAmount * price;
            SetTxt(sellAmount, totalPrice);
        }
    }

    public void SetTxt(int sellAmount, int totalPrice)
    {
        this.sellAmount = sellAmount;
        this.totalPrice = totalPrice;
        amountSellTxt.text = $"{sellAmount}";
        ttPriceTxt.text = $"Total Price : {totalPrice}";
        if (DataItem.Instance.GetAmountRipe(id, btnType) > 0)
        {
            amountTxt.text = $"Amount : {DataItem.Instance.GetAmountRipe(id, btnType)}";
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
