using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameSett : MonoBehaviour
{
    public Slider VolumeSlider;
    public Slider mouseSlider;
    public Settings settings;
    

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
    }
    public void ChangeSensitivity()
    {
        settings.sensitivity = mouseSlider.value;
    }
}