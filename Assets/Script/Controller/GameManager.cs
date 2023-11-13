using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    READY, PLAYING, FINISH, OpenSetting, HINT
}
public class GameManager : Singleton<GameManager>
{
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
    }

    private void OnApplicationQuit()
    {
        playerController.dataPlayer.Save();
    }
}
