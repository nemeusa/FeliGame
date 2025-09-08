using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : States
{
    FSM<TypeFSM> _fsm;
    EnemyCat _enemyCat;

    List<Nodes> _path;

    Transform _pathPosition;

    public WalkState(FSM<TypeFSM> fsm, EnemyCat enemyCat)
    {
        _fsm = fsm;
        _enemyCat = enemyCat;
    }

    public void OnEnter()
    {
        Debug.Log("into the patrol");
        //_enemyCat.GetComponent<MeshRenderer>().material.color = Color.white;
        if (_enemyCat.patrolPoints != null && _enemyCat.patrolPoints.Count > 1)
        {
            Nodes nearest = null;
            float minDist = Mathf.Infinity;

            for (int i = 0; i < _enemyCat.patrolPoints.Count; i++)
            {
                float dist = Vector2.Distance(_enemyCat.transform.position, _enemyCat.patrolPoints[i].transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    nearest = _enemyCat.patrolPoints[i];
                    _enemyCat.patrolIndex = i;
                }
            }

            GoToNextPatrol();
        }
    }

    public void OnUpdate()
    {
        //Debug.Log("update patrol");

        if (_enemyCat.fov.InFOV(_enemyCat.characterTarget))
        {
            _fsm.ChangeState(TypeFSM.Pursuit);
        }
    }

    public void OnExit()
    {
        //Debug.Log("exit patrol");
        _enemyCat.StopCoroutine(FollowPath(_path));
    }


    void GoToNextPatrol()
    {
        var current = _enemyCat.patrolPoints[_enemyCat.patrolIndex];
        var next = _enemyCat.patrolPoints[(_enemyCat.patrolIndex + 1) % _enemyCat.patrolPoints.Count];

        var path = _enemyCat.gameManager.pathfinding.CalculateAStar(current, next);
        _path = path;

   

        if (path.Count > 0)
        {
            if (_enemyCat.pathRoutine != null)
                _enemyCat.StopCoroutine(_enemyCat.pathRoutine);
            _enemyCat.pathRoutine = _enemyCat.StartCoroutine(FollowPath(path));
        }

        _enemyCat.patrolIndex = (_enemyCat.patrolIndex + 1) % _enemyCat.patrolPoints.Count;
    }

    IEnumerator FollowPath(List<Nodes> path)
    {
        _enemyCat.transform.position = path[0].transform.position;
        path.RemoveAt(0);

        while (path.Count > 0)
        {
            if (_fsm.CurrentStateKey != TypeFSM.Walk)
                yield break;


            _enemyCat.FollowTarget(path[0].transform);

            Vector2 dir = path[0].transform.position - _enemyCat.transform.position;

            if (dir.magnitude <= 0.2f)
                path.RemoveAt(0);

            yield return null;
        }

        yield return new WaitForSeconds(_enemyCat._waitPoint);
        GoToNextPatrol();
    }


}
