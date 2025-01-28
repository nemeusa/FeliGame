using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class GuideArrow : MonoBehaviour
{
    public Transform target; // El objeto al que la flecha debe apuntar.

    void Update()
    {
        if (target != null)
        {
            // Calcular la dirección hacia el objetivo
            Vector2 direction = target.position - transform.position;

            // Calcular el ángulo hacia la dirección
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Aplicar la rotación a la flecha
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));



        }
    }
}
