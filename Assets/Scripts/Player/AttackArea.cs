using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private bool _isChargeAttack;
    [SerializeField] private int _points;
    

    private void OnTriggerStay2D (Collider2D Other)
    {
        if (Other.CompareTag("Enemy"))
        {
           Other.gameObject.GetComponent<EnemyLife>().TakeDamage(Damage);
        }
        if(Other.CompareTag("Attack") && _isChargeAttack)
        {
            Destroy(Other.gameObject);
            PointsCounter.Instance.AddPoints(_points);
        }

    }
}
