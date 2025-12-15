using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    Animator _attackAni;

    private void Awake()
    {
        _attackAni = GetComponent<Animator>();
    }

    public void Finishttack()
    {
        _attackAni.SetBool("IsAttack", false);

    }
}
