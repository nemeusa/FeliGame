using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float Life;
    public void TakeDamage(float Damage)
    {
        Life = Life - Damage;
        Debug.Log("Enemy have " + Life + " from life");

        if (Life <= 0)
        {
            Debug.Log("Enemigo Eliminado");
            Destroy(this.gameObject);
        }
    }
}
