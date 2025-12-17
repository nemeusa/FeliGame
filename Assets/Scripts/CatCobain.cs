using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCobain : MonoBehaviour
{
    [Header("Follow System")]
    [SerializeField] Transform _followPoint;
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    public static CatCobain _cobain;
    public bool _catFollow;
    [SerializeField] int _points;
    private bool IsFacingRight = false;
    Rigidbody2D _rb;

    [Header("Shoot")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _speedBullet;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _detectionRange;

    private float _nextFireTime;

    private void Awake()
    {
        _cobain = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Follow();
        if(_catFollow)
        {
            ShootSystem();
        }
    }
    private void Follow()
    {
        if (_catFollow && _followPoint != null)
        {
            Vector2 _direction = (_followPoint.position - transform.position).normalized;
            _rb.velocity = _direction * _speed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }

        
    }

    private void ShootSystem()
    {
        EnemyCat target = FindNearestEnemy();
        if (target != null && Time.time >= _nextFireTime)
        {
            Shoot(target.transform);
            _nextFireTime = Time.time + 1f / _fireRate;
            
        }
        else
        {
            if (_player != null)
            {
                bool IsPlayerRight = transform.position.x < _player.position.x;
                Flip(IsPlayerRight);
            }
        }
    }

    private void Shoot(Transform _target)
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        Vector2 _direction = (_target.position - _firePoint.position).normalized;
        _bullet.GetComponent<Rigidbody2D>().velocity = _direction * _speedBullet;

    }

    EnemyCat FindNearestEnemy()
    {
        EnemyCat _nearestEnemy = null;
        float shortestDistance = _detectionRange;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                _nearestEnemy = enemy.GetComponent<EnemyCat>();
                bool IsPlayerRight = transform.position.x < enemy.transform.position.x;
                Flip(IsPlayerRight);
            }
        }
        return _nearestEnemy;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !_catFollow)
        {
            //_player = collision.transform;
            _catFollow = true;

            PointsCounter.Instance.AddPoints(_points);
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
