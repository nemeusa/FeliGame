using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float Life;
    Transform Player;
    [SerializeField] private LayerMask _wall;
    private int _points = 20;

    private void Start()
    {
        Player = FindObjectOfType<PlayerMovement>().transform;
    }
    public void TakeDamage(float Damage)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (Player.position - transform.position).normalized, 4, _wall);
        //if (hit.collider != null && hit.collider.gameObject != Player.gameObject)
        //{
            // Hay una pared en el medio, asi que no lo dañan
         //   return;
        //}

        Life = Life - Damage;
        //Debug.Log("Enemy have " + Life + " from life");

        if (Life <= 0 && !hit)
        {
            Debug.Log("Enemigo Eliminado");
            Destroy(this.gameObject);
            if(PointsCounter.Instance != null)
            {
                PointsCounter.Instance.AddPoints(_points);
            }
            Debug.Log("ganaste " + _points + " puntos");
        }
    }
}
