using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePlayer : MonoBehaviour
{
    Animator _playerAnimator;
    [SerializeField] PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void FinishAttack()
    {
        //_playerAttack.ResetAttack();
        _playerAnimator.SetBool("Attack", false);
    }


}
