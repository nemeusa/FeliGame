using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

    public PlayerMovement playerScript;

    [HideInInspector]
    public Vector3 lastKnownPosition;
    [HideInInspector]
    public Nodes lastKnownNode;

    [HideInInspector]
    bool _IsFacingRight = true;

    public Rigidbody2D rb;

    public float minFollowDistancePlayer;
    public float minAttackDistancePlayer;

    public GameObject attackArea;

    public float attackTime;

    public float damage = 5;

    public EnemyAttackArea attackScript;

    public Animation attackAni;

    void Awake()
    {
        attackScript = GetComponentInChildren<EnemyAttackArea>();
        rb = GetComponent<Rigidbody2D>();
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

    public void FollowTarget(Transform target)
    {
        Vector2 dir = target.transform.position - transform.position;

        dir.Normalize();

        Vector3 movement = new Vector3(dir.x, dir.y, 0f) * speed * Time.deltaTime;
        transform.position += movement;

        Flip(target);
    }

    public void Flip(Transform target)
    {
        Vector2 dir = target.position - transform.position;

        bool IsTargetRight = transform.position.x < target.transform.position.x;

        if ((_IsFacingRight && !IsTargetRight) || (!_IsFacingRight && IsTargetRight))
        {
            _IsFacingRight = IsTargetRight; //  acá sincronizas

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            fov.IsFacingRight = _IsFacingRight;
        }
    }

    public bool Mindistance(float minDistance) => Vector2.Distance(transform.position,
            characterTarget.position) < minDistance;

    public Node FindClosestNode()
    {
        Node closest = null;
        float minDist = Mathf.Infinity;
        //foreach (var node in gameManager.pathfinding.GetAllNodes())
        //{
        //    float dist = Vector3.Distance(transform.position, node.transform.position);
        //    if (dist < minDist)
        //    {
        //        minDist = dist;
        //        closest = node;
        //    }
        //}
        return closest;
    }

}

public enum TypeFSM
{
    Walk,
    Pursuit,
    Attack,
    Death
}
