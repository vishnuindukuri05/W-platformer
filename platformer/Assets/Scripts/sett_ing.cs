using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class sett_ing : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        // Debug.Log(volume);
        audioMixer.SetFloat("Volume", volume);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = (volume + 80) * 0.01f;
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}