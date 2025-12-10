using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWithPlayerPref : MonoBehaviour
{
    public static SaveWithPlayerPref instance;

    private void Awake()
    {
        instance = this;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Wins", GameManager.instance.winTimes);

        PlayerPrefs.SetInt("dogsColletibles", GameManager.instance.dogCollect);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        GameManager.instance.dogCollect = PlayerPrefs.GetInt("dogsColletibles", 0);
        GameManager.instance.CollectDogs();

    }

    public void LoadDataMenu()
    {
        GameManager.instance.winTimes = PlayerPrefs.GetInt("Wins", 0);
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
