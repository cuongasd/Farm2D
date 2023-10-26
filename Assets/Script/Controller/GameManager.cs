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
    public SpriteRenderer mapRenderer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
