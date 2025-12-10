using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCat : MonoBehaviour
{

    public FSM<TypeFSM> fsm;

    [Header ("Movement")]
    public float speed = 3f;
    [HideInInspector] public Rigidbody2D rb;


    [Header ("Attack")]
    public int damage = 1;
    public float attackRange = 3f;
    [SerializeField] float cooldown = 2;
    public float minFollowDistancePlayer;
    public float minAttackDistancePlayer;

    private float attackTime;
    [HideInInspector] public Animator attackAni;
    private RaycastHit2D[] hits;


    [Header ("Ref")]
    public GameObject attackArea;
    [SerializeField] LayerMask playerLayer;


    [Header ("Waypoints")]
    public List<CustomNodes> patrolPoints;
    public float _waitPoint;
    public int patrolIndex = 0;
    public Coroutine pathRoutine;

    [HideInInspector] public PathManager pathManager;
    [HideInInspector] public FOV fov;
    [HideInInspector] public Transform characterTarget;
    [HideInInspector] public Vector3 lastKnownPosition;
    [HideInInspector] public CustomNodes lastKnownNode;
    [HideInInspector] bool _IsFacingRight = true;


    private void Start()
    {
        characterTarget = GameManager.instance.player;
        pathManager = GameManager.instance.pathManager;
    }

    void Awake()
    {
       
        attackAni = attackArea.GetComponent<Animator>();
        fov = GetComponent<FOV>();
        rb = GetComponent<Rigidbody2D>();
        fsm = new FSM<TypeFSM>();
        fsm.AddState(TypeFSM.Walk, new WalkState(fsm, this));
        fsm.AddState(TypeFSM.Pursuit, new PursuitState(fsm, this));
        fsm.AddState(TypeFSM.Attack, new AttackState(fsm, this));
        fsm.AddState(TypeFSM.Death, new DeathState(fsm, this));
        fsm.AddState(TypeFSM.Returning, new ReturnWalkState(fsm, this));

        fsm.ChangeState(TypeFSM.Walk);
    }

    void Update()
    {
        if (attackTime > 0)
        attackTime -= Time.deltaTime;

        if (characterTarget == null) return;
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

    public bool Mindistance(Transform target,float minDistance) => Vector2.Distance(transform.position,
            target.position) < minDistance;

    public CustomNodes FindClosestNode()
    {
        CustomNodes closest = null;
        float minDist = Mathf.Infinity;
        foreach (var node in pathManager.pathfinding.GetAllNodes())
        {
            float dist = Vector3.Distance(transform.position, node.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = node;
            }
        }
        return closest;
    }


    public void AttackRay()
    {
        bool attackDist = Mindistance(characterTarget, minAttackDistancePlayer);

        if (!attackDist) return;

        if (attackTime > 0) return;

        Debug.Log("ataca");
        attackAni.SetBool("IsAttack", true);

        hits = Physics2D.CircleCastAll(attackArea.transform.position, attackRange, transform.right, 0f, playerLayer);

        //if (hit.collider != null)
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log("Golpeó a: " + hits[i].collider.name);

            PlayerLife player = hits[i].collider.GetComponent<PlayerLife>();
            if (player != null)
            {
                player.TakeHit(damage, attackArea.transform);
            }
        }
        attackTime = cooldown;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackArea.transform.position, attackRange);
    }


}

public enum TypeFSM
{
    Walk,
    Pursuit,
    Attack,
    Returning,
    Death
}
