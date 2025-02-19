using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public GameObject KeyPrefab;
    public Transform[] Houses;

    void Start()
    {
        SpawnKeys();
    }

    void SpawnKeys()
    {
        if (Houses.Length == 0)
        {
            Debug.LogWarning("No hay casas asignadas en el array.");
            return;
        }

        Debug.Log("llave aparecio");

        int randomIndex = Random.Range(0, Houses.Length);
        Instantiate(KeyPrefab, Houses[randomIndex].position, Quaternion.identity);
    }
}
