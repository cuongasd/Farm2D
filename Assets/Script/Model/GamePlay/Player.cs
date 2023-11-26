using UnityEngine;
[System.Serializable]
public class Player 
{
    public Player(Vector3 pos, float y)
    {
        coins = 0;
        exp = 100;
        this.pos = pos;
        rotationY = y;
    }
    public float coins;
    public int exp;
    public Vector3 pos;
    public float rotationY;
}
