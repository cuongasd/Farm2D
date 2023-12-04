using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableCtrl : MonoBehaviour
{
    private Available available;
    public int price;
    public int exp;
    public void OnMouseUpAsButton()
    {
        if (!available.isExist) return;
        DataPlayer.Instance.AddCoin(price);
        DataPlayer.Instance.AddExp(exp);
        available.isExist = false;
        DataMap.Instance.SetAvailable(available);
        SetInfo(available);
    }

    public void SetInfo(Available available)
    {
        this.available = available;
        gameObject.SetActive(available.isExist);
    }
}
