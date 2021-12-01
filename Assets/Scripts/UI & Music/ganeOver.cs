using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ganeOver : MonoBehaviour
{
  bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void EndGame()
    {
        if(gameHasEnded== false)
        {
            gameHasEnded = true;
            Debug.Log("You're dead");
            Invoke("restartGame",restartDelay);
        }
    }

    public void restartCheckpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
