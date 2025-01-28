using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    private float Damage;

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            Other.gameObject.GetComponent<PlayerLife>().TakeDamage(Damage);
        }

    }
}
