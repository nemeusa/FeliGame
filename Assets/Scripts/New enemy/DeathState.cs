using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : States
{
    FSM<TypeFSM> _fsm;
    EnemyCat _enemyCat;

    public DeathState(FSM<TypeFSM> fsm, EnemyCat enemyCat)
    {
        _fsm = fsm;
        _enemyCat = enemyCat;
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }
}
