using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerLife : MonoBehaviour
{
    [Header("Life")]
    [SerializeField] private int _maxLife;
    [SerializeField] private int _currentLife;
    //[SerializeField] LifeBar barLife;
    [SerializeField] HearthContainer _hearthsLife;
    public GameManager gameManager;
    public PlayerSoundEffects playerSFX;

    [Header("Cooldown")]
    [SerializeField] private float cooldown;
    private float _lastDamage;
    [SerializeField] private Animator _playerAni;
    [SerializeField] private float _dontControlTime, _controlTimeInvincible;
    private PlayerMovement PlayerMovement;

    private void Start()
    {
        _hearthsLife.HearthsActive(_currentLife);
        PlayerMovement = GetComponent<PlayerMovement>();
        //Animator = GetComponent<Animator>();
        if (playerSFX == null) playerSFX = GetComponent<PlayerSoundEffects>();
    }

    public void TakeHit(int damage, Transform target)
    {
        TakeDamage(damage);
        TakePostReboud(target);
    }


    private void TakeDamage(int Damage)
    {

        if (!_playerAni.GetBool("Hit"))
        {
            _playerAni.SetBool("Attack", false);
            _currentLife = _currentLife - Damage;
            //Debug.Log("you are " + _currentLife + " from life");
            //Debug.Log("you get " + Damage + " from damage");

            _hearthsLife.HearthsActive(_currentLife);

            playerSFX.PlayDamageSound();
            if (_currentLife <= 0)
            {
                gameManager.DefeatedMenu();
                Debug.Log("Moriste :(");
                Destroy(this.gameObject);
            }
        }
    }

    public void AddLife()
    {
        playerSFX.PlayAddLifeSound();
        if (_currentLife > _maxLife) return;
        _currentLife++;
        _hearthsLife.HearthsActive(_currentLife);
    }

    private void TakePostReboud(Transform target)
    {
        Vector2 direction = (transform.position - target.position).normalized;

        if (_currentLife >= 1)
        {
            StartCoroutine(ControlLose());
            StartCoroutine(Invincible());
            PlayerMovement.Reboud(direction);
        }
    }

    private IEnumerator Invincible()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        _playerAni.SetBool("Hit", true);
        yield return new WaitForSeconds(_controlTimeInvincible);
        _playerAni.SetBool("Hit", false);
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }
    private IEnumerator ControlLose()
    {
        PlayerMovement.DontMove = true;
        yield return new WaitForSeconds(_dontControlTime);
        PlayerMovement.DontMove = false;
    }

}
