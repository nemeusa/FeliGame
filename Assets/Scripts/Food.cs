using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerLife playerlife = collision.GetComponent<PlayerLife>();
        if (playerlife != null)
        {
            playerlife.AddLife();
            Destroy(gameObject);
        }
    }
}
