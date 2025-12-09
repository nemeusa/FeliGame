using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulley : MonoBehaviour
{
    [SerializeField] private float Speed;
    public Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        rb = GetComponent<Rigidbody2D>();

        LaunchProjectile();

    }

    [SerializeField] private float Damage;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        PlayerLife playerHP = Collider.GetComponent<PlayerLife>();
        if (playerHP != null)
        {
            playerHP.TakeHit(Damage, transform);
            Destroy(gameObject);
        }
        if (Collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }


    void LaunchProjectile()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rb.velocity = directionToPlayer * Speed;
        StartCoroutine(DestroyProyectile());
    }

    IEnumerator DestroyProyectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);

    }

    void OnColliderEnter2D()
    {
        Destroy(gameObject);
    }

}
