using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Animator AniHouse;

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            AniHouse.Play("Ceiling Back");
        }
    }

    private void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            AniHouse.Play("Ceiling Enter");
        }

    }
}
