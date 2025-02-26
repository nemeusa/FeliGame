using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerLife : MonoBehaviour
{
    [Header("Life")]
    [SerializeField] private float MaxLife;
    [SerializeField] private float Life;
    [SerializeField] LifeBar barLife;
    public GameManager gameManager;
    public PlayerSoundEffects playerSFX;

    [Header("Cooldown")]
    [SerializeField] private float cooldown;
    private float _lastDamage;
    [SerializeField] private Animator Animator;
    [SerializeField] private float DontControlTime, ControlTimeInvincible;
    private PlayerMovement PlayerMovement;

    private void Start()
    {
        Life = MaxLife;
        barLife._BarLife(Life);
        PlayerMovement = GetComponent<PlayerMovement>();
        //Animator = GetComponent<Animator>();
        if (playerSFX == null) playerSFX = GetComponent<PlayerSoundEffects>();
    }

    public void TakeDamage(float Damage)
    {
        //if ((Time.time - _lastDamage) < ControlTimeInvincible)
        //{
        //    return;
        //}

        //_lastDamage = Time.time;

        if (!Animator.GetBool("Hit"))
        {
            Life = Life - Damage;
            barLife.actuallyLife(Life);
            Debug.Log("you are " + Life + " from life");
            Debug.Log("you get " + Damage + " from damage");


            gameManager.CheckDefeatedCondition(Life);

            if (Life <= 0)
            {
                Debug.Log("Moriste :(");
                Destroy(this.gameObject);
            }
            playerSFX.PlayDamageSound();
        }
    }

    public void TakeDamages(Vector2 position)
    {

        StartCoroutine(ControlLose());
        StartCoroutine(Invincible());
        PlayerMovement.Reboud(position);
    }

    private IEnumerator Invincible()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        Animator.SetBool("Hit", true);
        yield return new WaitForSeconds(ControlTimeInvincible);
        Animator.SetBool("Hit", false);
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }
    private IEnumerator ControlLose()
    {
        PlayerMovement.DontMove = true;
        yield return new WaitForSeconds(DontControlTime);
        PlayerMovement.DontMove = false;
    }

}
