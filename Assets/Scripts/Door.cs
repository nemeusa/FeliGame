using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject NotKey;
    public GameObject Key1;
    public GameObject OpenDoor;
    public GameObject TheDoor;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private Animator AniPlayer;
    [SerializeField] private Animator AniArrow;
    [SerializeField] private GameObject Player;

    [SerializeField] GameManager _manages;

    public Animator AniDoor;

    void Start()
    {
        Key1.SetActive(false);
        NotKey.SetActive(false);
        OpenDoor.SetActive(false);
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag.Equals("Key"))
        {
            Key.Keys += 1;
            Destroy(other.gameObject);
            AniPlayer.SetBool("Get Key", true);
            AniArrow.Play("Get Key");

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Door") && Key.Keys == 0)
        {
            NotKey.SetActive(true);
        }

        if (other.tag.Equals("Door") && Key.Keys == 1)
        {
            Key1.SetActive(true);
            OpenDoor.SetActive(true);

            if (Input.GetButton("Jump"))
            {
                //WinScreen.SetActive(true);
                _manages.WinMenu();
                //Player.GetComponent<PlayerLife>().enabled = false;
                //Player.GetComponent<PlayerAttack>().enabled = false;
            }
        }

        if (other.tag.Equals("Store") && Input.GetButton("Jump"))
        {
            _manages.StoreMenu();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Door") && Key.Keys == 0)
        {
            NotKey.SetActive(false);
        }

        if (other.tag.Equals("Door") && Key.Keys == 1)
        {
            Key1.SetActive(false);
            OpenDoor.SetActive(false);
        }
    }

    public void ButtonOpenDoor()
    {
        AniDoor.SetTrigger("Open");
    }
}

