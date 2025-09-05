using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    //[SerializeField] private float _damage;
    EnemyCat _enemyCat;

    private void Awake()
    {
        _enemyCat = GetComponentInParent<EnemyCat>();
    }

    private void OnTriggerStay2D(Collider2D Other)
    {
        PlayerLife player = Other.GetComponent<PlayerLife>();
        if (player != null)
        {
            player.TakeDamage(_enemyCat.damage);
        }

    }
}
