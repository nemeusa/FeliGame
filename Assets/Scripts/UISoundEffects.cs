using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class UISoundEffects : MonoBehaviour
{
    AudioSource _myAudioSource;

    void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
    }


    public void PlayButtonSound()
    {
        _myAudioSource.Play();
    }


}
