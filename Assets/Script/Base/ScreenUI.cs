using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    protected UIController uiController;
    public virtual void Initialize(UIController uiController)
    {
        this.uiController = uiController;
    }
    public virtual void Active()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactive()
    {
        gameObject.SetActive(false);
    }
}
