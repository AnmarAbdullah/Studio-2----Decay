using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourPlatformsTask : MonoBehaviour
{
    public GameObject[] Platforms;
    public ParticleSystem[] PlatformVisuals;
    public int PlatformIndex;
    [SerializeField] float switchTimer;
    [SerializeField] float turnTimer;
    public float Meter;
    public Image MeterUI;
    void Start()
    {
        //challengeMeter[challengeMeter.Length] = GetComponent<PlatformCollision>();
        //MeterUI = GetComponent<Image>();
        MeterUI.gameObject.SetActive(false);
    }
    void Update()
    {
        switchTimer += Time.deltaTime;
        /*if(switchTimer > 10.01f)
        {
            switchTimer = 0;
        }*/
        if (switchTimer >= 16)
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

    void PlatformTriggered()
    {
        PlatformVisuals[PlatformIndex].Play();
        MeterUI.gameObject.SetActive(true);
        Invoke(nameof(PlatformHalt), 13);
    }
    void PlatformHalt()
    {
        PlatformVisuals[PlatformIndex].Stop();
        PlatformIndex = 4;
        Debug.Log("hellooo");
        MeterUI.gameObject.SetActive(false);
    }
}
