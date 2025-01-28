using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform Player;

    [SerializeField] private float Vision;

    public GameObject Bullet;

    [SerializeField] private float DelayBullet;
    private float TimeBullet;

    void Shoot()
    {
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z));
    }

    void Update()
    {
        TimeBullet = TimeBullet + Time.deltaTime;

        if (Player == null) return;

        if (Vision > Player.position.x)
        {
            if (TimeBullet > DelayBullet)
            {
                Shoot();
                TimeBullet = 0;
            }
        }

    }
}
