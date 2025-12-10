using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;

    public PathManager pathManager;

    [SerializeField] GameObject _defeatedMenu, _winMenu, _store;
    [SerializeField] GameObject _pauseUI;
    [SerializeField] UISoundEffects _UISounds;
    private bool _altBool;
    private bool _isPause;

    [SerializeField] TMP_Text _dogsCollText;
    public int dogCollect;

    [SerializeField] TMP_Text _winTimesText;
    public int winTimes;

    public bool _inMenu;

    private void Awake()
    {
        instance = this;

       


    }

    private void Start()
    {
        if (!_inMenu) SaveWithPlayerPref.instance.LoadData();
        SaveWithPlayerPref.instance.LoadDataMenu();

        if (_inMenu) WinsTimes();
        if (_inMenu) return;
        CollectDogs();
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
    }

    public void WinsTimes()
    {
        _winTimesText.text = "Win times: " + winTimes;
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
