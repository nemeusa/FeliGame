using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("General")]
    [SerializeField] private float _timeToAttack;
    [SerializeField] Animator _playerAnimator;
    [SerializeField] private float _timeAttack;
    private float _timer = 0f;
    private float _time1;


    [Header ("Normal Attack")]
    public PlayerSoundEffects playerSFX;
    [SerializeField] private GameObject _attackArea, _chargeAttackArea;
    private bool _isAttacking;
    private bool _attackIsReady;

    [Header ("Charge Attack")]
    [SerializeField] private float _chargeTime;
    [SerializeField] private float _holdTime;
    private bool _isCharging;

    [Header ("Attack")]
    [SerializeField] private int _damage;
    [SerializeField] private bool _isChargeAttack;
    [SerializeField] private int _points;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _chargeAttackRange;
    private RaycastHit2D[] _hits;
    [SerializeField] Animator _attackAni;
    [SerializeField] Animator _chargeAttackAni;


    void Start()
    {
        //_attackArea = transform.GetChild(0).gameObject;
        if (playerSFX == null) playerSFX = GetComponent<PlayerSoundEffects>();
        //PlayerAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        _time1 += Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            Press();
        }
        if (_isCharging)
        {
            _holdTime += Time.deltaTime;
            if (_holdTime >= _chargeTime && !_attackIsReady)
            {
                //Debug.Log("ataque cargado inicia");
                _playerAnimator.SetBool("Charge", true);
                _attackIsReady = true;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
           PressEnd();
        }

        if (_isAttacking && !_attackIsReady)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeToAttack)
            {
                ResetAttack();
            }
        }

        if (_attackAni.GetBool("IsAttack")) AttackRay();
        if (_chargeAttackAni.GetBool("IsAttack")) ChargeAttackRay();

    }

    private void Attack()
    {
        _playerAnimator.SetBool("Attack", true);
        _attackAni.SetBool("IsAttack", true);
        playerSFX.PlayPunchSound();
        _isAttacking = true;
        //Debug.Log("ataque normal");
        _time1 = 0;
    }

    private void ChargeAttack()
    {
        _playerAnimator.SetBool("Charge", false);
        _playerAnimator.SetBool("Attack", true);
        _chargeAttackAni.SetBool("IsAttack", true);
        playerSFX.PlayChargeAttackSound();
        _isAttacking = true;
        //playerSFX
        ChargeAttackRay();
        //Debug.Log("ATAQUE CARGADOOO");
    }

    public void ResetAttack()
    {
        _timer = 0;
        _isAttacking = false;
        _attackIsReady = false;
        //_attackArea.SetActive(false);
        //_chargeAttackArea.SetActive(false);
        //_playerAnimator.SetBool("Attack", false);
    }

    public void Press()
    {
        _holdTime = 0f;
        _isCharging = true;
    }

    public void PressEnd()
    {
        if (_isCharging)
        {
            if (_attackIsReady)
            {
                ChargeAttack();
            }
            if (_time1 >= _timeAttack && !_isAttacking)
            {
                Attack();
            }
            _attackIsReady = false;
        }
            _holdTime = 0;
            _isCharging = false;
    }


    public void AttackRay()
    {


        _hits = Physics2D.CircleCastAll(_attackArea.transform.position, _attackRange, transform.right, 0f);

        for (int i = 0; i < _hits.Length; i++)
        {
            EnemyLife enemyLife = _hits[i].collider.GetComponent<EnemyLife>();
            if (enemyLife != null)
            {
                enemyLife.TakeHit(_damage, transform);
            }
        }
    }

    public void ChargeAttackRay()
    {

        _hits = Physics2D.CircleCastAll(_chargeAttackArea.transform.position, _chargeAttackRange, transform.right, 0f);

        for (int i = 0; i < _hits.Length; i++)
        {
            EnemyLife enemyLife = _hits[i].collider.GetComponent<EnemyLife>();
            if (enemyLife != null)
            {
                enemyLife.TakeHit(_damage * 2, transform);
            }
            if (_hits[i].collider.CompareTag("Attack"))
            {
                Destroy(_hits[i].collider.gameObject);
                PointsCounter.Instance.AddPoints(_points);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_attackArea.transform.position, _attackRange);
        Gizmos.DrawWireSphere(_chargeAttackArea.transform.position, _chargeAttackRange);
    }
}