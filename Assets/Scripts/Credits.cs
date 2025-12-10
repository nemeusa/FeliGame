using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] float speed;

    float multiplicator = 2.5f;

    bool multiActive;
    bool upActive;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow)) UpButton();
        if (Input.GetKeyUp(KeyCode.DownArrow)) MultiButton();

        if (transform.position.y < -54) upActive = false;
        if (transform.position.y < 10.78f)
        {
            Vector3 dir = new Vector3(0, 54, 0);
            if (!upActive)
            {
                if (!multiActive)
                    transform.position += dir * speed * Time.deltaTime;

                else transform.position += dir * speed * multiplicator * Time.deltaTime;
            }
            else transform.position += dir * speed * -multiplicator * Time.deltaTime;

        }
        else StartCoroutine(NextScreen());
    }

    public void MultiButton()
    {
        upActive = false;
        multiActive = !multiActive;
    }

    public void UpButton()
    {
        multiActive = false;
        upActive = !upActive;
    }

    IEnumerator NextScreen()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");

    }
}
