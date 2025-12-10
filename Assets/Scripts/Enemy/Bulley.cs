using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulley : MonoBehaviour
{
    [SerializeField] private float Speed;
    public Transform player;
    private Rigidbody2D rb;
    [SerializeField] private int _damage;

    void Start()
    {
        player = GameManager.instance.player;
        rb = GetComponent<Rigidbody2D>();

        LaunchProjectile();

    }


    void OnTriggerEnter2D(Collider2D Collider)
    {
        PlayerLife playerHP = Collider.GetComponent<PlayerLife>();
        if (playerHP != null)
        {
            playerHP.TakeHit(_damage, transform);
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
