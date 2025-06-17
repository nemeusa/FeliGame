using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _defeatedMenu, _winMenu, _store;
    [SerializeField] GameObject _pauseUI;
    [SerializeField] UISoundEffects _UISounds;
    private bool _altBool;
    private bool _isPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _altBool = !_altBool;
            PauseLevel(_altBool);
            _pauseUI.SetActive(_altBool);
            _UISounds.PlayButtonSound();
            _store.SetActive(false);
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
            _isPause = pause;
            if (pause) Time.timeScale = 0f;
            else Time.timeScale = 1f;
    }

    void DefeatedMenu()
    {
        PauseLevel(true);
        _defeatedMenu.SetActive(true);
    }

    public void WinMenu()
    {
        SceneManager.LoadScene("Credits");
        //PauseLevel(true);
        //_winMenu.SetActive(true);
    }
    
    public void StoreMenu()
    {
        PauseLevel(true);
        _store.SetActive(true);
    }

}
