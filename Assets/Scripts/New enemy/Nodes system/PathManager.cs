using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static PathManager instance;

    public Pathfinding pathfinding;
    public Nodes start, end;
    public PlayerMovement player;
    public LayerMask layerMask;

    public List<Nodes> allNodes;

    public List<EnemyCat> allEnemies;
    private void Awake()
    {
        allNodes = new List<Nodes>(FindObjectsOfType<Nodes>());
        instance = this;
    }

    private void Update()
    {
        if (start != null && end != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var path = pathfinding.CalculateAStar(start, end);

                player.SetPath(path);
            }
        }
    }
    public void SetStartNode(Nodes node)
    {
        if (start != null)
            start.GetComponent<MeshRenderer>().material.color = Color.white;

        start = node;
        start.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void SetGoalNode(Nodes node)
    {
        if (end != null)
            end.GetComponent<MeshRenderer>().material.color = Color.white;


        end = node;
        start.GetComponent<MeshRenderer>().material.color = Color.green;
    }


    public bool InLineOfSight(Vector3 start, Vector3 end)
    {
        var dir = end - start;
        return !Physics.Raycast(start, dir, dir.magnitude, layerMask);
    }

    public void AlertNearbyEnemies(Nodes lastKnownNode)
    {
        foreach (var enemy in allEnemies)
        {
            if (enemy.fsm.CurrentStateKey != TypeFSM.Pursuit)
            {
                enemy.lastKnownNode = lastKnownNode;
               // enemy._fsm.ChangeState(TypeFSM.Searching);
            }
        }
    }
}
