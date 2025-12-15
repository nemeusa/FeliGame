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
            _altBool = !_altBool;
            PauseLevel(_altBool);
            _pauseUI.SetActive(_altBool);
            _UISounds.PlayButtonSound();
            _store.SetActive(false);
        }

    }

    public void CollectDogs()
    {
        _dogsCollText.text = "Dogs: " + dogCollect;
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

    public void PauseLevel(bool pause)
    {

        if (!_defeatedMenu) SaveWithPlayerPref.instance.LoadData();

        _isPause = pause;
            if (pause) Time.timeScale = 0f;
            else Time.timeScale = 1f;
    }

    public void DefeatedMenu()
    {
        PauseLevel(true);
        _defeatedMenu.SetActive(true);
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
