using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float offSet = 4f;
    private Vector3 offSetDir;

    private void Awake()
    {
        if (target == null) target = FindObjectOfType<PlayerLife>().transform;
    }

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
