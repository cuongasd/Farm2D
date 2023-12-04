using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SettingPopup : PopupUI
{
    [SerializeField] Button closeBtn;
    [SerializeField] Button soundBtn;
    [SerializeField] Button musicBtn;
    [SerializeField] Button vibrateBtn;
    [SerializeField] GameObject[] OnObjects;
    [SerializeField] GameObject[] OffObjects;
    [SerializeField] RectTransform popup;
    private bool pauseGame;
    private int vibrateOption
    {
        get { return PlayerPrefs.GetInt("key_config_vibrate", 1); }
        set { PlayerPrefs.SetInt("key_config_vibrate", value); }
    }
    public override void Initialize(UIController uiController)
    {
        base.Initialize(uiController);
        closeBtn.onClick.AddListener(Hide);
        //homeBtn.onClick.AddListener(BackHome);
        soundBtn.onClick.AddListener(Sound);
        musicBtn.onClick.AddListener(Music);
        vibrateBtn.onClick.AddListener(Vibrate);


        OnObjects[0].SetActive(AudioManager.SoundSetting == 1);
        OffObjects[0].SetActive(AudioManager.SoundSetting != 1);

        OnObjects[1].SetActive(AudioManager.MusicSetting == 1);
        OffObjects[1].SetActive(AudioManager.MusicSetting != 1);

        OnObjects[2].SetActive(vibrateOption == 1);
        OffObjects[2].SetActive(vibrateOption != 1);
    }
    public override void Show(Action onClose)
    {
        base.Show(onClose);
        popup.anchoredPosition = new Vector2(0, 1000f);
        popup.DOAnchorPosY(0, 0.5f).SetEase(Ease.OutBack);
    }
    public void Pause(bool status)
    {
        pauseGame = status;
    }
    private void Sound()
    {
        if (AudioManager.SoundSetting != 1)
        {
            AudioManager.Instance.EnableSound(true);
            AudioManager.Instance.PlayOneShot("on_off", 5f);
        }
        else
        {
            AudioManager.Instance.EnableSound(false);
        }
        OnObjects[0].SetActive(AudioManager.SoundSetting == 1);
        OffObjects[0].SetActive(AudioManager.SoundSetting != 1);
    }
    private void Music()
    {
        if (AudioManager.MusicSetting != 1)
        {
            AudioManager.Instance.EnableMusic(true);
        }
        else
        {
            AudioManager.Instance.EnableMusic(false);
        }
        AudioManager.Instance.PlayOneShot("on_off", 5f);
        OnObjects[1].SetActive(AudioManager.MusicSetting == 1);
        OffObjects[1].SetActive(AudioManager.MusicSetting != 1);
    }
    private void Vibrate()
    {
        if (vibrateOption != 0)
        {
            vibrateOption = 0;
        }
        else
        {
            vibrateOption = 1;
        }
        OnObjects[2].SetActive(vibrateOption == 1);
        OffObjects[2].SetActive(vibrateOption != 1);
        AudioManager.Instance.PlayOneShot("on_off", 5f);
    }
    //private void Rate()
    //{
    //    SDKManager.Instance.showRate();
    //}
    public override void Hide()
    {
        base.Hide();
    }
}
