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
    }

    public void OnUpdate()
    {
        _enemyCat.FollowTarget(_enemyCat.characterTarget.transform);

        bool followDist = _enemyCat.Mindistance(_enemyCat.characterTarget, _enemyCat.minFollowDistancePlayer);

        if (!_enemyCat.fov.InFOV(_enemyCat.characterTarget) && !followDist)
        {
            _fsm.ChangeState(TypeFSM.Returning);
        }


        _enemyCat.AttackRay();

    }
    public void OnExit()
    {
    }
}
