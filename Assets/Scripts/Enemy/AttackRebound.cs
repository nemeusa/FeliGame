using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AttackRebound : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D Other)
    { 
        if (Other.gameObject.CompareTag("Player"))
        {
            Vector2 direction = (Other.transform.position - transform.position).normalized;

            Other.gameObject.GetComponent<PlayerLife>().TakeDamages(direction);

            //Debug.Log("AAA ME TOCO");
        }

    }
}
