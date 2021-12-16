using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuu : MonoBehaviour
{
    int index =1;
    //public GameObject mainMenu;
    //public GameObject options;
    public void PlayGame()
    {
        Debug.Log("start");
        SceneManager.LoadScene("Main Scene");
       // Time.timeScale = 1f;
    }

    public void GotoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

