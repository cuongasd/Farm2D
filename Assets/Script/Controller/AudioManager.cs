using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class AudioManager : Singleton<AudioManager>
{
    public static int MusicSetting
    {
        get { return PlayerPrefs.GetInt("music_setting", 1); }
        set { PlayerPrefs.SetInt("music_setting", value); }
    }
    public static int SoundSetting
    {
        get { return PlayerPrefs.GetInt("sound_setting", 1); }
        set { PlayerPrefs.SetInt("sound_setting", value); }
    }
    [SerializeField] AudioContainerSO commonSound;
    [SerializeField] AudioContainerSO musics;
    [SerializeField] AudioSource soundPlayer;
    [SerializeField] AudioSource musicPlayer;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public void PlayOneShot(AudioClip audioClip, float volume, float delay = 0, Transform target = null)
    {
        if (SoundSetting != 1) return;
        if (audioClip == null) return;
        if (delay == 0)
        {
            float newVolume = volume;
            soundPlayer.PlayOneShot(audioClip, newVolume);
        }
        else
        {
            StartCoroutine(IEDeplayPlayOneShot(audioClip, volume, delay, target));
        }
    }
    public void PlayOneShot(string clipName, float volume, float delay = 0, Transform target = null)
    {
        if (SoundSetting != 1) return;
        AudioClip clip = commonSound.GetClip(clipName);
        if (clip != null)
        {
            if (delay == 0)
            {
                float newVolume = volume;
                soundPlayer.PlayOneShot(clip, newVolume);
            }
            else
            {
                StartCoroutine(IEDeplayPlayOneShot(clip, volume, delay, target));
            }
        }

    }
    IEnumerator IEDeplayPlayOneShot(AudioClip audioClip, float volume, float delay = 0, Transform target = null)
    {
        float timer = delay;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        float newVolume = volume;
        soundPlayer.PlayOneShot(audioClip, newVolume);
    }
    public void PlayMusic(string clipName, float volume, bool isLoop)
    {
        AudioClip clip = musics.GetClip(clipName);
        if (clip == null) return;
        musicPlayer.clip = clip;
        musicPlayer.loop = isLoop;
        if (MusicSetting != 1) musicPlayer.volume = 0; else musicPlayer.volume = volume;
        musicPlayer.Play();
    }
    public void PlayMusic(AudioClip clipName, float volume, bool isLoop)
    {
        if (clipName == null) return;
        musicPlayer.clip = clipName;
        musicPlayer.loop = isLoop;
        if (MusicSetting != 1) musicPlayer.volume = 0; else musicPlayer.volume = volume;
        musicPlayer.Play();
    }
    public void StopAll()
    {
        StopMusic();
        StopSound();
    }
    public void StopSound()
    {
        soundPlayer.Stop();
    }
    public void StopMusic()
    {
        musicPlayer.Stop();
    }
    public void ResumeMusic()
    {
        musicPlayer.Play();
    }
    public void EnableMusic(bool status)
    {
        MusicSetting = status ? 1 : 0;
        if (MusicSetting != 1)
        {
            musicPlayer.volume = 0;
        }
        else
        {
            musicPlayer.volume = 1f;
        }
    }
    public void EnableSound(bool status)
    {
        SoundSetting = status ? 1 : 0;
    }
}
