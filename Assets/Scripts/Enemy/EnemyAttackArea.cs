using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField] private float Damage;

    private void OnTriggerStay2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            Other.gameObject.GetComponent<PlayerLife>().TakeDamage(Damage);
        }

    }
}
