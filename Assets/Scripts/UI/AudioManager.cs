using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
   
    [HideInInspector]
    public float masterVol;
    [HideInInspector]
    public float musicVol;
    [HideInInspector]
    public float sfxVol;
    [SerializeField] private AudioMixer _mixer;

    private void Awake()
    {
        instance = this;
    }

    public void SetMasterVolume(float value)
    {
        masterVol = value;
        Debug.Log(masterVol);
        _mixer.SetFloat("Master", Mathf.Log10(masterVol) * 20.0f);
    }

    public void SetMusicVolume(float value)
    {
        musicVol = value;
        _mixer.SetFloat("Music", Mathf.Log10(value) * 20.0f);
    }

    public void SetSFXVolume(float value)
    {
        sfxVol = value;
        _mixer.SetFloat("SFX", Mathf.Log10(value) * 20.0f);
    }
}
