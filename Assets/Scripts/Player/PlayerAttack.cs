using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private GameObject AttackArea;
    private bool Attacking = false;
    [SerializeField] private float TimeToAttack;
    private float Timer = 0f;

    [SerializeField] private float TimeAttack;
    private float Time1;
    public PlayerSoundEffects playerSFX;
    [SerializeField] Animator PlayerAnimator;

    void Start()
    {
        AttackArea = transform.GetChild(0).gameObject;
        if (playerSFX == null) playerSFX = GetComponent<PlayerSoundEffects>();
        //PlayerAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {
        Time1 += Time.deltaTime; 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Time1 >= TimeAttack)
            {
                Attack();
                Time1 = 0;
            }
           

        }
        if(Attacking)
        {
            Timer += Time.deltaTime;

            if(Timer >= TimeToAttack)
            {
                Timer = 0f;
                Attacking = false;
                AttackArea.SetActive(Attacking);
                PlayerAnimator.SetBool("Attack", false);
            }
        }
    }

    private void Attack()
    {
        PlayerAnimator.SetBool("Attack", true);
        playerSFX.PlayPunchSound();
        Attacking = true;
        AttackArea.SetActive(Attacking);
    }
}