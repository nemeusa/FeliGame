using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _defeatedMenu, _winMenu;

    public void CheckDefeatedCondition(float life)
    {
        if (life <= 0)
        {
            PauseLevel(true);
            DefeatedMenu();
        }

    }


    public void PauseLevel(bool pause)
    {
        if (pause) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    void DefeatedMenu()
    {
        _defeatedMenu.SetActive(true);
    }

    public void WinMenu()
    {
        _winMenu.SetActive(true);
    }

}
