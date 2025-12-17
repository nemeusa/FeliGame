using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static int Keys;
    AudioSource audioSource;
    [SerializeField] AudioClip clip;

    void Start()
    {
        Keys = 0;
    }



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

        }
    }
}
