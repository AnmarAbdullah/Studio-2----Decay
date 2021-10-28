using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    float currentMeter;
    float MAXMeter = 10000;
    float currentHealth;
    float MaxHealth = 300;

    public Image MeterUI;
    public Image HealthUI;
   
    PlayerController player;
    FourPlatformsTask meter;
   // GunSwitcher switcher;


    void Start()
    {
        MeterUI = GetComponent<Image>();
        HealthUI = GetComponent<Image>();

       // switcher = FindObjectOfType<GunSwitcher>();

        meter = FindObjectOfType<FourPlatformsTask>();
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        currentMeter = meter.Meter;
        MeterUI.fillAmount = currentMeter / MAXMeter;

        currentHealth = player.Health;
        HealthUI.fillAmount = currentHealth / MaxHealth;
    }
}
