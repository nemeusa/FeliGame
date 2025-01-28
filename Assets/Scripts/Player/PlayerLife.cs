using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerLife : MonoBehaviour
{
    private float Life;
    [SerializeField] private float MaxLife;
    [SerializeField] LifeBar barLife;
    public GameManager gameManager;

    public PlayerSoundEffects playerSFX;
    private PlayerMovement PlayerMovement;
    private Animator Animator;
    [SerializeField] private float DontControlTime, ControlTimeInvincible;

    private void Start()
    {
        Life = MaxLife;
        barLife._BarLife(Life);
        PlayerMovement = GetComponent<PlayerMovement>();
        Animator = GetComponent<Animator>();
        if (playerSFX == null) playerSFX = GetComponent<PlayerSoundEffects>();
    }

    public void TakeDamage(float Damage)
    {
        Life = Life - Damage;
        barLife.actuallyLife(Life);
        Debug.Log("you are " + Life + " from life");

        playerSFX.PlayDamageSound();

        gameManager.CheckDefeatedCondition(Life);

        if (Life <= 0)
        {
            Debug.Log("Moriste :(");
            Destroy(this.gameObject);
        }
    }

    public void TakeDamages(Vector2 position)
    {
        Animator.SetTrigger("Hit");
        StartCoroutine(ControlLose());
        StartCoroutine(Invincible());
        PlayerMovement.Reboud(position);
    }

    private IEnumerator Invincible()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        yield return new WaitForSeconds(ControlTimeInvincible);
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }
    private IEnumerator ControlLose()
    {
        PlayerMovement.DontMove = true;
        yield return new WaitForSeconds(DontControlTime);
        PlayerMovement.DontMove = false;
    }

}
