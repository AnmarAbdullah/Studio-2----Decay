using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FourPlatformsTask : MonoBehaviour
{
    public GameObject[] Platforms;
    /// public ParticleSystem[] PlatformVisuals;
    public GameObject[] PlatformVisuals;

    public PlayerController player;
    public ParticleSystem gate;
    
    public int PlatformIndex;
    [SerializeField] float switchTimer;
    
    public float Meter;
    float currentMeter;
    float MAXMeter = 50000;

    public Image MeterUIBackground;
    public Image MeterUI;
    public TextMeshProUGUI challengeEND;
    float challengeEndTimer;
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
        if (Meter >= MAXMeter)
        {
            MeterUIBackground.gameObject.SetActive(false);
            challengeEND.gameObject.SetActive(true);
            gate.gameObject.SetActive(false);
            challengeEndTimer += Time.deltaTime;
            if(challengeEndTimer >= 3)
            {
                challengeEND.gameObject.SetActive(false);
            }
        }
    }

    void PlatformTriggered()
    {
        /// PlatformVisuals[PlatformIndex].Play();
        
            PlatformVisuals[PlatformIndex].gameObject.SetActive(true);
            MeterUIBackground.gameObject.SetActive(true);
        
        Invoke(nameof(PlatformHalt), 17);
    }
    void PlatformHalt()
    {
        ///PlatformVisuals[PlatformIndex].Stop();
        PlatformVisuals[PlatformIndex].gameObject.SetActive(false);
        PlatformIndex = 4;
        //MeterUIBackground.gameObject.SetActive(false);
    }
}
