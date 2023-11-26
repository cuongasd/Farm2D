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
        curHarvestTime = 0;
        isRipe = false;
    }

    public void Update()
    {
        if (curHarvestTime < harvestTime)
        {
            glass.SetActive(true);
            meshRenderer.enabled = false;
            curHarvestTime += Time.deltaTime;
        } else
        {
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
