using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAction : MonoBehaviour
{
    [Header("<color=orange>Audio</color>")]
    [Range(0, 1)][SerializeField] private float _masterVolume = 1;
    [Range(0, 1)][SerializeField] private float _musicVolume = 1;
    [Range(0, 1)][SerializeField] private float _sfxVolume = 1;

    [Header("<color=yellow>Sliders</color>")]
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private void Start()
    {
        if (AudioManager.instance.masterVol != 0.0f)
        {
            _masterSlider.value = AudioManager.instance.masterVol;
        }
        else
        {
            _masterSlider.value = _masterVolume;
            AudioManager.instance.SetMasterVolume(_masterVolume);
        }

        if (AudioManager.instance.musicVol != 0.0f)
        {
            _musicSlider.value = AudioManager.instance.musicVol;
        }
        else
        {
            _musicSlider.value = _musicVolume;
            AudioManager.instance.SetMusicVolume(_musicVolume);
        }

        if (AudioManager.instance.sfxVol != 0.0f)
        {
            _sfxSlider.value = AudioManager.instance.sfxVol;
        }
        else
        {
            _sfxSlider.value = _sfxVolume;
            AudioManager.instance.SetSFXVolume(_sfxVolume);
        }
    }



    public void SetMasterVolume(float value)
    {
        AudioManager.instance.SetMasterVolume(value);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetMusicVolume(value);
    }

    public void SetSfxVolume(float value)
    {
        AudioManager.instance.SetSFXVolume(value);
    }
}
