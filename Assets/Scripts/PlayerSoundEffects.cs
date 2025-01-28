using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundEffects : MonoBehaviour
{
    AudioSource _myAudioSource;
    public AudioClip[] damageSound;
    public AudioClip[] shootSound;

    void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayDamageSound()
    {
        int sound = SoundSelected(damageSound.Length);
        _myAudioSource.PlayOneShot(damageSound[sound]);
    }

    public void PlayPunchSound()
    {
        int sound = SoundSelected(shootSound.Length);
        _myAudioSource.PlayOneShot(shootSound[sound]);
    }


    int SoundSelected(int totalSounds)
    {
        return Random.Range(0, totalSounds);
    }
}
