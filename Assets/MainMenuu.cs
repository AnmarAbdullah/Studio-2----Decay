using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuu : MonoBehaviour
{
    int index =1;
    public GameObject mainMenu;
    public GameObject options;
    public void PlayGame()
    {
        Debug.Log("start");
        options.SetActive(false);
        SceneManager.LoadScene(index);
    }
    public void GoToOptionsMenu()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

