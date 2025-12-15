using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteEnemy : MonoBehaviour
{
    Animator _enemyAni;

    private void Awake()
    {
        _enemyAni = GetComponent<Animator>();
    }
    public void FinishAttack()
    {
        _enemyAni.SetBool("Hit", false);
    }


    public void FinishDeath()
    {
        _enemyAni.SetBool("Death", false);
    }
}
