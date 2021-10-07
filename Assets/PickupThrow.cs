using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupThrow : MonoBehaviour
{
    public Transform Player;
    public Transform playerCam;
    [SerializeField] bool hasPlayer;
    [SerializeField] bool beingCarried;
    [SerializeField] bool touched;
    public float throwforce;

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, Player.position);
        if(dist <= 2.5)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if(hasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwforce);
            }
        }
    }
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
