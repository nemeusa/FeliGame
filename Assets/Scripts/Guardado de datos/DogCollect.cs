using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCollect : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip clip;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player != null)
        {
            audioSource.PlayOneShot(clip);
            GameManager.instance.dogCollect++;
            GameManager.instance.CollectDogs();
            SaveWithPlayerPref.instance.SaveDataLevel();
            Destroy(gameObject);

        }
    }
}
