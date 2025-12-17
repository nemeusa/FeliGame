using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteMenuFeli : MonoBehaviour, IPointerDownHandler
{
    public AudioClip[] damageSound;
    Animator _playerAnimator;
    AudioSource _audioSource;
    bool _isAttack;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerAnimator = GetComponent<Animator>();
    }
    public void FinishJump()
    {
        MainMenuManager.instance.ChangeSceneAfterAni();
    }

    //public void DonAttack()
    //{
    //    _isAttack = false;
    //    _playerAnimator.SetBool("Attack", false);
    //    Debug.Log("Funciono xd");
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
    //    //if (!_isAttack)
    //    //StartCoroutine(AttackEnum());
    }

    //public void ButtonAttack()
    //{
    //    if (_isAttack) return;

    //    _isAttack = true;
    //    _playerAnimator.SetBool("Attack", true);
    //    int i = Random.Range(0, damageSound.Length);
    //    _audioSource.PlayOneShot(damageSound[i]);

    //}
    //public void ButtonCancellAttack()
    //{
    //    _isAttack = false;

    //}

    //IEnumerator AttackEnum()
    //{
    //    _isAttack = true;
    //    _playerAnimator.SetBool("Attack", true);
    //    int i = Random.Range(0, damageSound.Length);
    //    _audioSource.PlayOneShot(damageSound[i]);
    //    yield return new WaitForSeconds(1);
    //    _isAttack = false ;

    //}
}
