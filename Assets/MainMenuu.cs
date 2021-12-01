using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuu : MonoBehaviour
{
    int index =1;
    public void PlayGame()
    {
        Debug.Log("start");
        SceneManager.LoadScene(index);
    }
    public void GoToOptionsMenu()
    {
        SceneManager.LoadScene("options");
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

