using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameSett : MonoBehaviour
{
    private AudioListener mixer;
    public Slider mouseSensitivity;
    public Slider camSensitivity;
    public Slider volume;
    int index = 1;


    public float CamSen;
    public float mouseSen;
    public float volumeControl;

    private void Start()
    {

        if (!PlayerPrefs.HasKey("camSensitivity"))
        {
            PlayerPrefs.SetFloat("camSensitivity", 1f);
        }

        if (!PlayerPrefs.HasKey("mouseSensitivity"))
        {
            PlayerPrefs.SetFloat("mouseSensitivity", 1f);
        }
        CamSen = PlayerPrefs.GetFloat("camSensitivity");
        mouseSen = PlayerPrefs.GetFloat("mouseSensitivity");
    }

    public void Update()
    {
        
    }


    // Update is called once per frame
    public void SaveSettings()
    {

        PlayerPrefs.SetFloat("camSensitivity", camSensitivity.value);
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity.value);
        PlayerPrefs.Save();
    }

    public void SetVolumeLevel(float sliderValue)
    {
        volume.onValueChanged.AddListener((sliderValue) =>  AudioListener.volume = sliderValue);
        //mixer.SetFloat("muwsicVol", Mathf.Log10(sliderValue));
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}