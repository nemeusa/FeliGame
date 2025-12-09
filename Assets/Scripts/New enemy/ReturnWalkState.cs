using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnWalkState : States
{
    FSM<TypeFSM> _fsm;
    EnemyCat _enemyCat;

    public ReturnWalkState(FSM<TypeFSM> fsm, EnemyCat enemyCat)
    {
        _fsm = fsm;
        _enemyCat = enemyCat;
    }

    public void OnEnter()
    {
       // _enemyCat.GetComponent<MeshRenderer>().material.color = Color.white;

        Debug.Log("Returning ENTER");

        // buscar el nodo de patrulla más cercano
        CustomNodes nearestPatrolNode = null;
        float minDist = Mathf.Infinity;
        foreach (var patrolNode in _enemyCat.patrolPoints)
        {
            float dist = Vector3.Distance(_enemyCat.transform.position, patrolNode.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearestPatrolNode = patrolNode;
            }
        }

        if (nearestPatrolNode != null)
        {
            // calcular A*
            var path = _enemyCat.gameManager.pathfinding.CalculateAStar(
                _enemyCat.FindClosestNode(), nearestPatrolNode);

            if (_enemyCat.pathRoutine != null)
                _enemyCat.StopCoroutine(_enemyCat.pathRoutine);

            _enemyCat.pathRoutine = _enemyCat.StartCoroutine(FollowReturnPath(path));
        }
    }

    public void OnUpdate()
    {
        if (_enemyCat.fov.InFOV(_enemyCat.characterTarget))
        {
            _fsm.ChangeState(TypeFSM.Pursuit);
        }
    }

    public void OnExit()
    {
        if (_enemyCat.pathRoutine != null)
            _enemyCat.StopCoroutine(_enemyCat.pathRoutine);
    }

    IEnumerator FollowReturnPath(List<CustomNodes> path)
    {
        if (path == null || path.Count == 0)
        {
            _fsm.ChangeState(TypeFSM.Walk);
            yield break;
        }

        path.RemoveAt(0);

        while (path.Count > 0)
        {
            if (_fsm.CurrentStateKey != TypeFSM.Returning)
                yield break;

            _enemyCat.FollowTarget(path[0].transform);

            if (_enemyCat.Mindistance(path[0].transform, 0.2f))
                path.RemoveAt(0);

            yield return null;
        }

        _fsm.ChangeState(TypeFSM.Walk);
    }
}
