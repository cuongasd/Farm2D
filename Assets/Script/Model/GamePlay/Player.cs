using UnityEngine;
[System.Serializable]
public class Player 
{
    public Player(Vector3 pos, float y)
    {
        coins = 0;
        level = 1;
        this.pos = pos;
        rotationY = y;
    }
    public float coins;
    public int level;
    public Vector3 pos;
    public float rotationY;
}
