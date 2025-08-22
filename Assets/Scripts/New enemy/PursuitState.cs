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
        Debug.Log("player in fov update");

    }
    public void OnExit()
    {
    }

}
