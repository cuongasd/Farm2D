using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayScreen : ScreenUI
{
    [Header ("Content")]
    public Text level;
    public Text txtCoin;
    public Button btnShop;
    public Button btnSetting;
    public FixedJoystick fixedJoystick;
    public List<BtnItembase> btnItembases;
    public BtnCropsCtrl btnCropsCtrl;
    public BtnAnimalCtrl btnAnimalCtrl;
    public Button btnCrops;
    public Button btnAnimal;
    public override void Initialize(UIController uiController)
    {
        base.Initialize(uiController);
        btnShop.onClick.AddListener(OnShop);
        btnSetting.onClick.AddListener(OnSetting);
        for (int i = 0; i < btnItembases.Count; i++)
        {
            btnItembases[i].Initialize(this);
        }
        btnCrops.onClick.AddListener(OnCrops);
        btnAnimal.onClick.AddListener(OnAnimal);
    }

    public override void Active()
    {
        base.Active();
        OnCrops();
    }
    public void OnShop()
    {

    }

    public void OnSetting()
    {

    }

    public void SetBtnCrop(BtnCropsCtrl btnCropsCtrl)
    {
        for (int i = 0; i < btnItembases.Count; i++)
        {
            btnItembases[i].button.image.color = Color.white;
        }

        btnCropsCtrl.button.image.color = Color.blue;
        this.btnCropsCtrl = btnCropsCtrl;
    }

    public void SetBtnAnimals(BtnAnimalCtrl btnAnimalCtrl)
    {
        for (int i = 0; i < btnItembases.Count; i++)
        {
            btnItembases[i].button.image.color = Color.white;
        }

        btnAnimalCtrl.button.image.color = Color.blue;
        this.btnAnimalCtrl = btnAnimalCtrl;
    }
    public void OnCrops()
    {
        for (int i = 0; i < btnItembases.Count; i++)
        {
            if (btnItembases[i].type == BtnType.CROPS)
            {
                btnItembases[i].gameObject.SetActive(true);
            } else
            {
                btnItembases[i].gameObject.SetActive(false);
            }

            btnCrops.image.color = Color.green;
            btnAnimal.image.color = Color.white;
        }
    }

    public void OnAnimal()
    {
        for (int i = 0; i < btnItembases.Count; i++)
        {
            if (btnItembases[i].type == BtnType.ANIMAL)
            {
                btnItembases[i].gameObject.SetActive(true);
            }
            else
            {
                btnItembases[i].gameObject.SetActive(false);
            }

            btnCrops.image.color = Color.white;
            btnAnimal.image.color = Color.green;
        }
    }
}
