using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public ScreenUI[] screens;
    public PopupUI[] popups;
    private Queue<PopupUI> queuePopup;
    private GameManager gameManager;
    public void Initialize(GameManager gameManager)
    {
        this.gameManager = gameManager;
        queuePopup = new Queue<PopupUI>();
        for (int i = 0; i < popups.Length; i++)
        {
            popups[i].Initialize(this);
        }
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].Initialize(this);
        }
    }

    public void DeactiveAllScreen(bool showTopUI)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].Deactive();
        }
    }
    public T ActiveScreen<T>(bool showTopUI = true)
    {
        T screen = default;
        for (int i = 0; i < screens.Length; i++)
        {
            if (screens[i] is T)
            {
                screens[i].Active();
                screen = screens[i].GetComponent<T>();
            }
            else
            {
                screens[i].Deactive();
            }
        }
        return screen;
    }

    public T GetScreen<T>()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (screens[i] is T)
            {
                return screens[i].GetComponent<T>();
            }
        }
        return default;
    }

    public T ShowPopup<T>(System.Action onClose)
    {
        T popup = default;
        for (int i = 0; i < popups.Length; i++)
        {
            if (popups[i] is T)
            {
                popups[i].Show(onClose);
                popup = popups[i].GetComponent<T>();
                queuePopup.Enqueue(popup as PopupUI);
            }
        }
        return popup;
    }

    public T GetPopup<T>()
    {
        T popup = default;
        for (int i = 0; i < popups.Length; i++)
        {
            if (popups[i] is T)
            {
                popup = popups[i].GetComponent<T>();
            }
        }
        return popup;
    }
}
