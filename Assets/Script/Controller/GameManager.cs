using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    READY, PLAYING, FINISH, OpenSetting, HINT
}
public class GameManager : Singleton<GameManager>
{
    public int firstPlay
    {
        get => PlayerPrefs.GetInt("first_play", 0);
        set => PlayerPrefs.GetInt("first_play", value);
    }
    public static GameState gameState;
    public PlayerController playerController;
    public UIController uiController;
    public Transform itemHolder;
    public DataMap dataMap;

    private void Start()
    {
        playerController.Initialize(this);
        uiController.Initialize(this);
        uiController.ActiveScreen<PlayScreen>();
        dataMap.LoadData();
        if (firstPlay <= 0)
        {
            DataPlayer.Instance.AddCoin(1000);
            firstPlay++;
        }
    }

    private void OnApplicationQuit()
    {
        DataPlayer.Instance.Save();
        dataMap.SaveGround();
    }
}
