using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnItemBuy : MonoBehaviour
{
    public Button btnBuy;
    public int id;
    public BtnType btnType;
    public void Initialize()
    {
        btnBuy.onClick.AddListener(OnBuy);
    }

    public void OnBuy()
    {
        
    }
}
