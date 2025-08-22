using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCat : MonoBehaviour
{
    public FSM<TypeFSM> fsm;

    public float speed = 3f;
    public List<Nodes> patrolPoints;

    public float _waitPoint;

    public int patrolIndex = 0;
    public Coroutine pathRoutine;

    public PathManager gameManager;

    public FOV fov;

    public Transform characterTarget;

    [HideInInspector]
    public Vector3 lastKnownPosition;
    [HideInInspector]
    public Nodes lastKnownNode;

    [HideInInspector]
    bool _IsFacingRight = true;


    void Awake()
    {
        fsm = new FSM<TypeFSM>();
        fsm.AddState(TypeFSM.Walk, new WalkState(fsm, this));
        fsm.AddState(TypeFSM.Pursuit, new PursuitState(fsm, this));
        fsm.AddState(TypeFSM.Attack, new AttackState(fsm, this));
        fsm.AddState(TypeFSM.Death, new DeathState(fsm, this));

        fsm.ChangeState(TypeFSM.Walk);
    }

    void Update()
    {
        fsm.Execute();
    }

    public void Flip(bool IsTargetRight)
    {
        if ((_IsFacingRight && !IsTargetRight) || (!_IsFacingRight && IsTargetRight))
        {
            _IsFacingRight = IsTargetRight; //  acá sincronizas

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            Debug.Log("Cat Look right = " + _IsFacingRight);
            // Si tu FOV está como hijo del enemigo
            fov.IsFacingRight = _IsFacingRight;
        }
    }

}

public enum TypeFSM
{
    Walk,
    Pursuit,
    Attack,
    Death
}
