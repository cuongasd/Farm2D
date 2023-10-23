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
    public MobileTouchCamera mobileTouch;
    // Start is called before the first frame update
    void Start()
    {
        mobileTouch.setCamPosLimit(this, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
