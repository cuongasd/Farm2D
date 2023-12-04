using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsController : ItemBase
{
    public int id;
    public float harvestTime;
    public float curHarvestTime;
    public bool isRipe;
    public GameObject glass;
    public MeshRenderer meshRenderer;
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
            timeImg.gameObject.SetActive(true);
            iconFinish.gameObject.SetActive(false);
            glass.SetActive(true);
            meshRenderer.enabled = false;
            curHarvestTime -= Time.deltaTime;
            timeTxt.text = $"{(int)(curHarvestTime / 60):00}:{(int)(curHarvestTime % 60):00}";
        }
        else
        {
            timeImg.gameObject.SetActive(false);
            iconFinish.gameObject.SetActive(true);
            isRipe = true;
            glass.SetActive(false);
            meshRenderer.enabled = true;
        }
    }

    public override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        if (!isRipe) return;
        Destroy(gameObject);
    }
}
