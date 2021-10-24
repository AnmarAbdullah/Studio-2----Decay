using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourPlatformUI : MonoBehaviour
{
    float currentMeter;
    float MAXMeter = 10000;
    public Image MeterUI;
    FourPlatformsTask meter;

    void Start()
    {
        MeterUI = GetComponent<Image>();
        meter = FindObjectOfType<FourPlatformsTask>();
    }

    void Update()
    {
        currentMeter = meter.Meter;
        MeterUI.fillAmount = currentMeter / MAXMeter;
    }
}
