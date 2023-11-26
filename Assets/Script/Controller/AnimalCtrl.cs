using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCtrl : ItemBase
{
    public float harvestTime;
    private float curHarvestTime;
    public bool isRipe;
    public Animator animator;
    public int exp;
    public void Initialize()
    {
        curHarvestTime = 0;
        isRipe = false;

    }

    public void Update()
    {
        if (curHarvestTime > harvestTime)
        {
            curHarvestTime += Time.deltaTime;
        }
        else
        {
            isRipe = true;
        }
    }

    public override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        if (!isRipe) return;
        Destroy(gameObject);
    }
}
