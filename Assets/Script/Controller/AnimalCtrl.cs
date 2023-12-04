using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCtrl : ItemBase
{
    public int id;
    public float harvestTime;
    public float curHarvestTime;
    public bool isRipe;
    public Animator animator;
    public int exp;
    public void Initialize()
    {
        curHarvestTime = harvestTime;
        isRipe = false;
        timeImg.transform.LookAt(new Vector3(0, 0, 90));
        iconFinish.transform.LookAt(new Vector3(0, 0, 90));
    }

    public void Update()
    {
        if (curHarvestTime > 0)
        {
            curHarvestTime -= Time.deltaTime;
            timeImg.gameObject.SetActive(true);
            iconFinish.gameObject.SetActive(false);
            timeTxt.text = $"{(int)(curHarvestTime / 60):00}:{(int)(curHarvestTime % 60):00}";
        }
        else
        {
            isRipe = true;
            timeImg.gameObject.SetActive(false);
            iconFinish.gameObject.SetActive(true);
        }
    }

    public override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        if (!isRipe) return;
        Destroy(gameObject);
    }
}
