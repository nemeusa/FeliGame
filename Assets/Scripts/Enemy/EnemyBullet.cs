using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform _spawnPoint;

    [SerializeField] private float Vision;
    [SerializeField] private bool _daius;
    [SerializeField] private bool _oldman;
    private bool IsFacingRight;

    public GameObject Bullet;

    [SerializeField] private float DelayBullet;
    private float TimeBullet;

    bool _IsFacingRight;

    private void Start()
    {
        Player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Shoot()
    {
        Instantiate(Bullet, _spawnPoint.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z));
    }

    void Update()
    {
        TimeBullet = TimeBullet + Time.deltaTime;

        if (Player == null) return;
        //if (_daius && CatCobain._cobain._catFollow && !_oldman)
        //{

        //}
        //if (_daius && !CatCobain._cobain._catFollow || _oldman)
        //{
            if (Mathf.Abs(transform.position.x - Player.position.x) <= Vision)
            {
                if (TimeBullet > DelayBullet)
                {
                    Shoot();
                    TimeBullet = 0;
                }
            }
       // }
        if(_oldman)
        {
            //bool IsPlayerRight = transform.position.x < Player.position.x;
            //Flip2(Player);
        }
    }


    public void Flip2(Transform target)
    {
        Vector2 dir = target.position - transform.position;

        bool IsTargetRight = transform.position.x < target.transform.position.x;

        if ((_IsFacingRight && !IsTargetRight) || (!_IsFacingRight && IsTargetRight))
        {
            _IsFacingRight = IsTargetRight; //  acá sincronizas

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            //fov.IsFacingRight = _IsFacingRight;
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
