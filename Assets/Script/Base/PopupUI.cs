using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    protected UIController uiController;
    protected Action onClose;
    public virtual void Initialize(UIController uiController)
    {
        this.uiController = uiController;
    }
    public virtual void Show(Action onClose)
    {
        this.onClose = onClose;
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
        onClose?.Invoke();
        onClose = null;
    }
}
