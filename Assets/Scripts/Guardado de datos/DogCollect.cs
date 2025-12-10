using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.dogCollect++;
        GameManager.instance.CollectDogs();
        SaveWithPlayerPref.instance.SaveDataLevel();
        Destroy(gameObject);
    }
}
