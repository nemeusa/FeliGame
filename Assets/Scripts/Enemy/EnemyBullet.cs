using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform _spawnPoint;

    [SerializeField] private float Vision;

    public GameObject Bullet;

    [SerializeField] private float DelayBullet;
    private float TimeBullet;

    void Shoot()
    {
        Instantiate(Bullet, _spawnPoint.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z));
    }

    void Update()
    {
        TimeBullet = TimeBullet + Time.deltaTime;

        if (Player == null) return;

        if (Mathf.Abs(transform.position.x - Player.position.x) <= Vision)
        {
            if (TimeBullet > DelayBullet)
            {
                Shoot();
                TimeBullet = 0;
            }
        }

    }
}
