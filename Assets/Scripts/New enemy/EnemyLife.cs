using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int _life;
    Transform _player;
    [SerializeField] private LayerMask _wall;
    private int _points = 20;
    [SerializeField] Animator _enemyAnim;
    EnemyCat _enemyCat;
    ParticleSystem _deathParticle;
    [SerializeField] private float _controlTimeInvincible;


    private void Awake()
    {
        _enemyCat = GetComponent<EnemyCat>();
        _deathParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        _player = GameManager.instance.player;
    }

    public void TakeHit(int damage, Transform target)
    {
        if (_enemyAnim.GetBool("Hit")) return;

        TakeDamage(damage);
        TakePostReboud(target);
    }

    void TakeDamage(int Damage)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (_player.position - transform.position).normalized, 4, _wall);
        if (hit) return; // Hay una pared en el medio, asi que no lo dañan

        //_deathParticle.Play();

        _life = _life - Damage;

        StartCoroutine(Invincible());

        //_enemyAnim.SetBool("Hit", true);

        if (_life <= 0)
        {
            Debug.Log("Enemigo Eliminado");
            //_deathParticle.Play();
            var d = Instantiate(_deathParticle, transform.position, Quaternion.identity);
            d.Play();
            _enemyAnim.SetBool("Death", true);
            if(PointsCounter.Instance != null)
            {
                PointsCounter.Instance.AddPoints(_points);
            }
            Debug.Log("ganaste " + _points + " puntos");
            Destroy(this.gameObject, 0.2f);
        }
    }


    void TakePostReboud(Transform target)
    {
        Vector2 direction = (transform.position - target.position).normalized;

        if (_life >= 1)
        {
            //StartCoroutine(ControlLose());
            //StartCoroutine(Invincible());
            _enemyCat.Reboud(direction);
        }
    }

    private IEnumerator Invincible()
    {
        _enemyAnim.SetBool("Hit", true);
        yield return new WaitForSeconds(_controlTimeInvincible);
        _enemyAnim.SetBool("Hit", false);
    }
}
