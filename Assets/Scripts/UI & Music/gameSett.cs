using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class gameSett : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider mouseSensitivity;
    public Slider camSensitivity;
    public Slider volume;

    public float CamSen;
    public float mouseSen;
    public int volumeControl;

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

    }

    private void Update()
    {

        CamSen = PlayerPrefs.GetFloat("camSensitivity");
        mouseSen = PlayerPrefs.GetFloat("mouseSensitivity");
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
        mixer.SetFloat("muwsicVol", Mathf.Log10(sliderValue));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}