using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] float Speed;
    [SerializeField] private float MinDistance;
    [SerializeField] private float MaxDistanceX, MaxDistanceY;
    [SerializeField] private float TimeAttack;
    private float Time1;
    private bool IsFacingRight = false;
    public float Damage;

    [SerializeField] private GameObject AttackArea;
    private bool Attacking = false;
    [SerializeField] private float TimeToAttack;
    private float Timer = 0f;


    private void Start()
    {
        AttackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        Time1 += Time.deltaTime;

        if (Player == null) return;

        if (Mathf.Abs(transform.position.x - Player.position.x) > MaxDistanceX)
        {

        }

        if (Mathf.Abs(transform.position.y - Player.position.y) > MaxDistanceY)
        {

        }

        else if (Mathf.Abs(transform.position.x - Player.position.x) > MinDistance && Mathf.Abs(transform.position.x - Player.position.x) < MaxDistanceX)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }

        else if (Mathf.Abs(transform.position.y - Player.position.y) > MinDistance && Mathf.Abs(transform.position.x - Player.position.x) < MaxDistanceY)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, Player.position) < MinDistance)
        {

            if (TimeAttack < Time1)
            {
                Attack();
                Time1 = 0;
            }
        }

        if (Attacking)
        {
            Timer += Time.deltaTime;

            if (Timer >= TimeToAttack)
            {
                Timer = 0f;
                Attacking = false;
                AttackArea.SetActive(Attacking);
            }
        }

        bool IsPlayerRight = transform.position.x < Player.position.x;
        Flip(IsPlayerRight);
    }

    void Attack()
    {
        Attacking = true;
        AttackArea.SetActive(Attacking);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().TakeDamage(Damage);
        }
    }

    void Flip(bool IsPlayerRight)
    {
        if ((IsFacingRight && !IsPlayerRight) || (!IsFacingRight && IsPlayerRight))
        {
            IsFacingRight = !IsFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
