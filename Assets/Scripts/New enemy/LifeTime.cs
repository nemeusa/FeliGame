using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] float _lifeTime = 25;
    void Update()
    {
        Destroy(gameObject, _lifeTime);
    }
}
