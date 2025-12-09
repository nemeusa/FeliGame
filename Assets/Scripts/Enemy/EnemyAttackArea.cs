using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    Animator attackAni;

    private void Awake()
    {
        attackAni = GetComponent<Animator>();
    }

    public void FinishAttacking()
    {
        attackAni.SetBool("IsAttack", false);

    }
}
