using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    public FourPlatformsTask platform;
    public float testingTimer;
    public int platformInd;


    void Start()
    {
        platform = GetComponentInParent<FourPlatformsTask>();
    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("hellooooo");
        if (platform.PlatformIndex == platformInd)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                testingTimer += Time.deltaTime * 1.2f;
                platform.Meter += testingTimer;
            }
        }
    }


}
