using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMusical : MonoBehaviour
{
    [SerializeField] int _damage;

    private void Update()
    {
        Destroy(gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyLife>().TakeHit(_damage, transform);
            Destroy(gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
