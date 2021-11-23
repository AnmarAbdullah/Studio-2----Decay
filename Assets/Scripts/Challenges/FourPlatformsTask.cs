using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourPlatformsTask : MonoBehaviour
{
    public GameObject[] Platforms;
    /// public ParticleSystem[] PlatformVisuals;
    public GameObject[] PlatformVisuals;

    public PlayerController player;
       
    public int PlatformIndex;
    [SerializeField] float switchTimer;
    [SerializeField] float turnTimer;
    
    public float Meter;
    float currentMeter;
    float MAXMeter = 20000;

    public Image MeterUIBackground;
    public Image MeterUI;
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (player.ChallengeIndex == 1 /*&& Meter <= 20000*/)
        {
            currentMeter = Meter;
            MeterUI.fillAmount = Meter / MAXMeter;
            switchTimer += Time.deltaTime;
            if (switchTimer >= 18)
            {
                PlatformIndex = Random.Range(0, Platforms.Length);
                var PlatformNumber = PlatformIndex;
                switchTimer = 0;
                switch (PlatformIndex)
                {
                    case 0:
                        PlatformTriggered();
                        break;
                    case 1:
                        PlatformTriggered();
                        break;
                    case 2:
                        PlatformTriggered();
                        break;
                    case 3:
                        PlatformTriggered();
                        break;
                }
            }
        }
        if(Meter >= 20000) MeterUIBackground.gameObject.SetActive(false);
    }

    void PlatformTriggered()
    {
        /// PlatformVisuals[PlatformIndex].Play();
        
            PlatformVisuals[PlatformIndex].gameObject.SetActive(true);
            MeterUIBackground.gameObject.SetActive(true);
        
        Invoke(nameof(PlatformHalt), 12);
    }
    void PlatformHalt()
    {
        ///PlatformVisuals[PlatformIndex].Stop();
        PlatformVisuals[PlatformIndex].gameObject.SetActive(false);
        PlatformIndex = 4;
        MeterUIBackground.gameObject.SetActive(false);
    }
}
