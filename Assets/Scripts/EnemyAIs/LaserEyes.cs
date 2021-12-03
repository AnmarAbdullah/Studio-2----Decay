using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{
    public Transform seekObject;
    void Update()
    {
        transform.LookAt(seekObject);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name);

        }
        
    }
}
