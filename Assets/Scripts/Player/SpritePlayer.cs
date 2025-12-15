using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePlayer : MonoBehaviour
{
    Animator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }
    public void FinishAttack()
    {
        _playerAnimator.SetBool("Attack", false);
    }


}
