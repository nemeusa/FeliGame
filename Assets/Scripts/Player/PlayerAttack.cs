using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("General")]
    [SerializeField] private float TimeToAttack;
    [SerializeField] Animator PlayerAnimator;
    [SerializeField] private float TimeAttack;
    private float Timer = 0f;
    private float Time1;


    [Header ("Normal Attack")]
    public PlayerSoundEffects playerSFX;
    [SerializeField] private GameObject AttackArea, _chargeAttackArea;
    private bool _isAttacking;
    private bool _attackIsReady;

    [Header ("Charge Attack")]
    [SerializeField] private float _chargeTime;
    [SerializeField] private float _holdTime;
    private bool _isCharging;


    void Start()
    {
        AttackArea = transform.GetChild(0).gameObject;
        if (playerSFX == null) playerSFX = GetComponent<PlayerSoundEffects>();
        //PlayerAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        Time1 += Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            _holdTime = 0f;
            _isCharging = true;
        }
        if (_isCharging)
        {
            _holdTime += Time.deltaTime;
            if (_holdTime >= _chargeTime && !_attackIsReady)
            {
                //Debug.Log("ataque cargado inicia");
                PlayerAnimator.SetBool("Charge", true);
                _attackIsReady = true;
            }
        }
        if (_isCharging && Input.GetButtonUp("Jump"))
        {
            if (_attackIsReady)
            {
                ChargeAttack();
            }
            else if (Time1 >= TimeAttack && !_isAttacking)
            {
                Attack();
            }
            _isCharging = false;
            _holdTime = 0;
            _attackIsReady = false;
        }

        if (_isAttacking && !_attackIsReady)
        {
            Timer += Time.deltaTime;
            if (Timer >= TimeToAttack)
            {
                ResetAttack();
            }
        }
    }

    private void Attack()
    {
        PlayerAnimator.SetBool("Attack", true);
        playerSFX.PlayPunchSound();
        _isAttacking = true;
        AttackArea.SetActive(true);
        //Debug.Log("ataque normal");
        Time1 = 0;
    }

    private void ChargeAttack()
    {
        PlayerAnimator.SetBool("Charge", false);
        PlayerAnimator.SetBool("Attack", true);
        playerSFX.PlayChargeAttackSound();
        _isAttacking = true;
        //playerSFX
        _chargeAttackArea.SetActive(true);
        //Debug.Log("ATAQUE CARGADOOO");
    }

    private void ResetAttack()
    {
        Timer = 0;
        _isAttacking = false;
        _attackIsReady = false;
        AttackArea.SetActive(false);
        _chargeAttackArea.SetActive(false);
        PlayerAnimator.SetBool("Attack", false);
    }
}