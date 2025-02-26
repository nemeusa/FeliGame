using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Follow System")]
    public bool _canFollow;
    [SerializeField] private Transform Player;
    [SerializeField] float Speed;
    [SerializeField] private float MinDistance;
    [SerializeField] private float MaxDistanceX, MaxDistanceY;
    private float Time1;
    private bool IsFacingRight = false;
    private bool _isFollow;

    [Header("Attack")]
    public float Damage;
    [SerializeField] private float TimeAttack;
    [SerializeField] private GameObject AttackArea;
    [SerializeField] private float TimeToAttack;
    private bool Attacking = false;
    private float Timer = 0f;

    [SerializeField] private LayerMask _wall;


    private void Start()
    {
        Player = FindObjectOfType<PlayerMovement>().transform;
        AttackArea = transform.GetChild(0).gameObject;
        _canFollow = true;
    }

    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Time1 += Time.deltaTime;

        if (Player == null) return;

        if (_isFollow)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (Player.position - transform.position).normalized, 4, _wall);
            if (hit.collider != null && hit.collider.gameObject != Player.gameObject)
            {
                //Debug.Log("toco pared");

                // Hay una pared en el medio, asi que no sigue al jugador
                return;
            }
        }

        if (Mathf.Abs(transform.position.x - Player.position.x) > MaxDistanceX)
        {
            _isFollow = false;
        }

        if (Mathf.Abs(transform.position.y - Player.position.y) > MaxDistanceY)
        {
            _isFollow = false;
        }

        else if (Mathf.Abs(transform.position.x - Player.position.x) > MinDistance && Mathf.Abs(transform.position.x - Player.position.x) < MaxDistanceX)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
            _isFollow = true;
        }

        else if (Mathf.Abs(transform.position.y - Player.position.y) > MinDistance && Mathf.Abs(transform.position.x - Player.position.x) < MaxDistanceY)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
            _isFollow = true;
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

    //private void OnTriggerStay2D(Collider2D other)
    //{

    //    if (other.CompareTag("Player"))
    //    {
    //        other.gameObject.GetComponent<PlayerLife>().TakeDamage(Damage);
    //    }
    //}

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
