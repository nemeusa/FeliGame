using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState : States
{
    FSM<TypeFSM> _fsm;
    EnemyCat _enemyCat;

    public PursuitState(FSM<TypeFSM> fsm, EnemyCat enemyCat)
    {
        _fsm = fsm;
        _enemyCat = enemyCat;
    }

    public void OnEnter()
    {
        Debug.Log("player in fov");
    }

    public void OnUpdate()
    {
        _enemyCat.FollowTarget(_enemyCat.characterTarget.transform);
        Debug.Log("player in fov update");

       bool followDist = _enemyCat.Mindistance(_enemyCat.minFollowDistancePlayer);

        if (!_enemyCat.fov.InFOV(_enemyCat.characterTarget) && !followDist)
        {
            _fsm.ChangeState(TypeFSM.Walk);
        }

        bool attackDist = _enemyCat.Mindistance(_enemyCat.minAttackDistancePlayer);

        if (attackDist) _enemyCat.StartCoroutine(Attack());

    }
    public void OnExit()
    {
    }


    IEnumerator Attack()
    {
        _enemyCat.attackArea.SetActive(true);
        yield return new WaitForSeconds(_enemyCat.attackTime);
        _enemyCat.attackArea.SetActive(false);
    }

}
