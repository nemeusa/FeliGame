using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PursuitState : States
{
    FSM<TypeFSM> _fsm;
    EnemyCat _enemyCat;
    float attackTimer;


    public PursuitState(FSM<TypeFSM> fsm, EnemyCat enemyCat)
    {
        _fsm = fsm;
        _enemyCat = enemyCat;
    }

    public void OnEnter()
    {
        //Debug.Log("player in fov");
    }

    public void OnUpdate()
    {
        _enemyCat.FollowTarget(_enemyCat.characterTarget.transform);
        //Debug.Log("player in fov update");

       bool followDist = _enemyCat.Mindistance(_enemyCat.characterTarget, _enemyCat.minFollowDistancePlayer);

        if (!_enemyCat.fov.InFOV(_enemyCat.characterTarget) && !followDist)
        {
            _fsm.ChangeState(TypeFSM.Returning);
        }

        //else _fsm.ChangeState(TypeFSM.Walk);

        Attack();

    }
    public void OnExit()
    {
    }


    void Attack()
    {
        //bool Attacking;

        //if (Attacking)
        //{
        //    attackTimer += Time.deltaTime;

        //    if (attackTimer >= _enemyCat.attackTime)
        //    {
        //        attackTimer = 0f;
                bool attackDist = _enemyCat.Mindistance(_enemyCat.characterTarget, _enemyCat.minAttackDistancePlayer);

                Debug.Log("atacando es: " + attackDist);

                if (attackDist) _enemyCat.StartCoroutine(AttackEnum());
        //    }
        //}
    }

    IEnumerator AttackEnum()
    {
        _enemyCat.attackArea.SetActive(true);
        _enemyCat.attackAni.SetBool("IsAttack", true);
        yield return new WaitForSeconds(_enemyCat.attackTime);
        _enemyCat.attackAni.SetBool("IsAttack", false);
        _enemyCat.attackArea.SetActive(false);
    }

}
