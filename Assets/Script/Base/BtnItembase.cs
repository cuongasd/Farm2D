using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BtnType
{
    CROPS,
    ANIMAL,
    FARMTOOL
}
public class BtnItembase : MonoBehaviour
{
    public int id;
    public BtnType type;
    public Button button;
    protected PlayScreen playScreen;
    public Text amountSpeedsTxt;
    public virtual void Initialize(PlayScreen playScreen, Item item)
    {
        this.playScreen = playScreen;
        button.image.color = playScreen.colorDefault;
        SetTxt(item);
    }

    public virtual void OnClick()
    {
    }

    public void SetTxt(Item item)
    {
        amountSpeedsTxt.text = $"{item.amountSpeeds}";
    }
}
