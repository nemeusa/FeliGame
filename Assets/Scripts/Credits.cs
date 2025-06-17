using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] float speed;
    void Start()
    {
        
    }

  
    void Update()
    {
        if (transform.position.y < 27)
        {
            Vector3 dir = new Vector3(0, 54, 0);
            transform.position += dir * speed * Time.deltaTime;

        }
        else StartCoroutine(NextScreen());
    }

    IEnumerator NextScreen()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");

    }
}
