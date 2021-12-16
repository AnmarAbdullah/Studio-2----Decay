using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{
    public Transform seekObject;
    private LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }
    void Update()
    {
        lr.SetPosition(0, transform.position);
        transform.LookAt(seekObject);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1000))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            PlayerController player = hit.transform.GetComponent<PlayerController>();
            if(player != null)
            {
                player.Health -= 5;
            }
        }
        else lr.SetPosition(1, transform.forward * 500);
        
    }
}
