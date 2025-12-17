using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] HearthContainer dogsContainer;

    public Transform player;

    public PathManager pathManager;

    [SerializeField] GameObject _defeatedMenu, _winMenu, _store;
    [SerializeField] GameObject _pauseUI;
    [SerializeField] UISoundEffects _UISounds;
    private bool _altBool;
    private bool _isPause;

    [SerializeField] TMP_Text _dogsCollText;
    public int dogCollect;
    public int maxDogCollect;

    [SerializeField] TMP_Text _winTimesText;
    public int winTimes;

    public bool _inMenu;

    private void Awake()
    {
        instance = this;
        if (_inMenu) return;
        PauseLevel(false);
        _pauseUI.SetActive(true);
        _pauseUI.SetActive(false);

        //PauseMenu();
    }

    private void Start()
    {
        if (!_inMenu)
        {
           GameStart();
        }

        if (_inMenu)
        {
            MenuStart();
        }
    }

    public void MenuStart()
    {
        SaveWithPlayerPref.instance.LoadDataMenu();
        WinsTimes();
        CollectMaxDogs();
    }

    public void GameStart()
    {
        SaveWithPlayerPref.instance.DeleteDataDogsLevel();
    }

    private void Update()
    {
        if (_inMenu) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }

    }

    public void CollectDogs()
    {
        _dogsCollText.text = "Dogs: " + dogCollect;
        if (dogsContainer == null) return;

        dogsContainer.HearthsActive(dogCollect);
    }

    public void CollectMaxDogs()
    {
        dogsContainer.HearthsActive(maxDogCollect);
    }

    public void WinsTimes()
    {
        _winTimesText.text = "Win times: " + winTimes;
    }

    public void PauseMenu()
    {
        _altBool = !_altBool;
        _pauseUI.SetActive(_altBool);
        PauseLevel(_altBool);
        SaveWithPlayerPref.instance.LoadData();
        _UISounds.PlayButtonSound();
        _store.SetActive(false);
    }

    public void PauseLevel(bool pause)
    {
        _isPause = pause;
            if (pause) Time.timeScale = 0f;
            else Time.timeScale = 1f;

        //if (!_defeatedMenu) 
        //if (pause) 
        //    SaveWithPlayerPref.instance.LoadData();
    }

    public void DefeatedMenu()
    {
        _defeatedMenu.SetActive(true);
        PauseLevel(true);
    }

    public void WinMenu()
    {
        if (maxDogCollect < dogCollect)
        maxDogCollect = dogCollect;
        winTimes++;
        SaveWithPlayerPref.instance.SaveData();
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
