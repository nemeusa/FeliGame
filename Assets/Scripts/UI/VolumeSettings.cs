using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _masterSlide;

    public void GeneralVolume()
    {
        float vol = _masterSlide.value;
        _mixer.SetFloat("Master", vol);
    }
}
