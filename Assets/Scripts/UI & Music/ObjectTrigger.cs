using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    public GameObject objectToInstanciate;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(objectToInstanciate,spawnPoint.position,spawnPoint.rotation);

    }
}
