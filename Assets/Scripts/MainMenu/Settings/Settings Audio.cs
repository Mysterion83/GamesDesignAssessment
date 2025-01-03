using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsAudio : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;
    [SerializeField]
    Slider MasterMixer;
    [SerializeField]
    Slider SFXMixer;
    [SerializeField]
    Slider MusicMixer;

    public void SetMasterVolume(float vol)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(vol) * 20);
    }
    public void SetSFXVolume(float vol)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(vol) * 20);
    }
    public void SetMusicVolume(float vol)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(vol) * 20);
    }
}
