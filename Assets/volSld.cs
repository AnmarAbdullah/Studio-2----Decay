using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volSld : MonoBehaviour
{
    public Slider volume;
    public float volumeControl;

    // Start is called before the first frame update
    void Start()
    {
        volume.onValueChanged.AddListener((v) => AudioListener.volume = v);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(AudioListener.volume);
    }
}
