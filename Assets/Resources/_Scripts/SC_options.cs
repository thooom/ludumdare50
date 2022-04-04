using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SC_options : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicPlayer;
    public float currentVolume;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Awake()
    {
        LoadSettings();
    }

    // Update is called once per frame


    public void setVolume()
    {
        currentVolume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
        musicPlayer.volume = currentVolume;
    }
    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("FullscreenPreference", 
                Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference", 
                currentVolume); 
    }
    
    public void LoadSettings()
    {
        musicPlayer = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = 
            Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
        /*if (PlayerPrefs.HasKey("VolumePreference"))
            volumeSlider.value = 
                        PlayerPrefs.GetFloat("VolumePreference");
        else
            volumeSlider.value = 
                        PlayerPrefs.GetFloat("VolumePreference");*/
    }
}
