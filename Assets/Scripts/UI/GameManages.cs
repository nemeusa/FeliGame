using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _defeatedMenu, _winMenu;
    [SerializeField] GameObject _pauseUI;
    [SerializeField] UISoundEffects _UISounds;
    private bool _altBool;
    private bool _beMenuScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _defeatedMenu && _winMenu)
        {
            _altBool = !_altBool;
            PauseLevel(_altBool);
            _pauseUI.SetActive(_altBool);
            _UISounds.PlayButtonSound();
        }

    }

    public void CheckDefeatedCondition(float life)
    {
        if (life <= 0)
        {
            //PauseLevel(true);
            DefeatedMenu();
        }

    }


    public void PauseLevel(bool pause)
    {
            if (pause) Time.timeScale = 0f;
            else Time.timeScale = 1f;
            Debug.Log("hay pausa lol" + _beMenuScreen);

    }

    void DefeatedMenu()
    {
        PauseLevel(true);
        _defeatedMenu.SetActive(true);
    }

    public void WinMenu()
    {
        PauseLevel(true);
        _winMenu.SetActive(true);
    }

}
