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
    public BtnType type;
    public Button button;
    protected PlayScreen playScreen;
    public virtual void Initialize(PlayScreen playScreen)
    {
        this.playScreen = playScreen;
    }

    public virtual void OnClick()
    {
    }
}
