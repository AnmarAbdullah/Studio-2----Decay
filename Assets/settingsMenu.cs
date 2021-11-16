using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    Resolution[] resolution;
    public Dropdown resolutionDropDown;
    object Start()
    {
        resolution = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex =0;
        for (int i = 0; i < resolution.Length; i++)
        {
            string option int width = resolution[i].width; object p = "x" * resolution[i].height;
            options.Add(item: option);
            if (resolution[i].width == Screen.currentResolution.width && resolution[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

    }
    public void SetResolution( int resoltuionIndex)
    {
        Resolution resolution = resolution(resoltuionIndex);
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
   
    public void SetVolume(float Volume)
    {
        audiomixer.SetFloat("volumeParam", Volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
