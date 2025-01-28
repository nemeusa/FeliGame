using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuesConfigs : MonoBehaviour
{
    public GameObject[] allMenues;
    public GameObject wantedActiveMenu;

    void Start()
    {
        if (allMenues.Length > 0)
        {

            foreach (var item in allMenues) item.SetActive(false);

            if (wantedActiveMenu != null) wantedActiveMenu.SetActive(true);
        }
    }

    public void ChangeSceneByNumber(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
