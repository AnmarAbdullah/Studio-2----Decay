using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourPlatformsTask : MonoBehaviour
{
    public GameObject[] Platforms;
    public ParticleSystem[] PlatformVisuals;
    public int PlatformIndex;
    [SerializeField] float switchTimer;
    [SerializeField] float turnTimer;
    public float Meter;
    void Start()
    {
        //challengeMeter[challengeMeter.Length] = GetComponent<PlatformCollision>();
    }
    void Update()
    {
        switchTimer += Time.deltaTime;
        /*if(switchTimer > 10.01f)
        {
            switchTimer = 0;
        }*/
        if (switchTimer >= 10)
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
        Invoke(("PlatformHalt"), 7);
    }
    void PlatformHalt()
    {
        PlatformVisuals[PlatformIndex].Stop();
        PlatformIndex = 4;
    }
}
