using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayScreen : ScreenUI
{
    [Header("Content")]
    public Button btnShop;
    public Button btnChest;
    public Button btnSetting;
    public FixedJoystick fixedJoystick;
    public List<BtnItembase> btnItembases;
    public BtnCropsCtrl btnCropsCtrl;
    public BtnAnimalCtrl btnAnimalCtrl;
    public Button btnCrops;
    public Button btnAnimal;
    public Color colorDefault;
    public Color colorSelect;
    public DataItem dataItem;
    public override void Initialize(UIController uiController)
    {
        base.Initialize(uiController);
        btnShop.onClick.AddListener(OnShop);
        btnChest.onClick.AddListener(OnChest);
        btnSetting.onClick.AddListener(OnSetting);
        dataItem.LoadData(btnItembases);
        for (int i = 0; i < btnItembases.Count; i++)
        {
            btnItembases[i].Initialize(this, dataItem.items.listItem[i]);
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
        uiController.ShowPopup<ShopPopup>(null);
    }

    public void OnChest()
    {
        uiController.ShowPopup<ChestPopup>(null);
    }

    public void OnSetting()
    {

    }

    public void SetBtnCrop(BtnCropsCtrl btnCropsCtrl)
    {
        for (int i = 0; i < btnItembases.Count; i++)
        {
            btnItembases[i].button.image.color = colorDefault;
        }

        btnCropsCtrl.button.image.color = colorSelect;
        this.btnCropsCtrl = btnCropsCtrl;
    }

    public void SetBtnAnimals(BtnAnimalCtrl btnAnimalCtrl)
    {
        for (int i = 0; i < btnItembases.Count; i++)
        {
            btnItembases[i].button.image.color = colorDefault;
        }

        btnAnimalCtrl.button.image.color = colorSelect;
        this.btnAnimalCtrl = btnAnimalCtrl;
    }
    public void OnCrops()
    {
        for (int i = 0; i < btnItembases.Count; i++)
        {
            if (btnItembases[i].type == BtnType.CROPS)
            {
                btnItembases[i].gameObject.SetActive(true);
            }
            else
            {
                btnItembases[i].gameObject.SetActive(false);
            }

            btnCrops.image.color = Color.green;
            btnAnimal.image.color = Color.white;
        }
        btnAnimalCtrl = null;
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
        btnCropsCtrl = null;
    }

    public void UpdateTxtItem()
    {
        for (int i = 0; i < btnItembases.Count; i++)
        {
            btnItembases[i].SetTxt(dataItem.items.listItem[i]);
        }

    }
}
