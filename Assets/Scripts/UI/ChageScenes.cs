using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChageScenes : MonoBehaviour
{
    public GameObject[] allMenues;
    public GameObject wantedActiveMenu;
    
    void Start()
    {
        foreach (var menu in allMenues)
        {
            menu.SetActive(false);
        }
        if (wantedActiveMenu != null) wantedActiveMenu.SetActive(true);
    }

    public void ChangeMyScene(Object sceneToChange)
    {
        SceneManager.LoadScene(sceneToChange.name);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
