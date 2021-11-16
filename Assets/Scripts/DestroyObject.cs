using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void Update()
    {
        Destroy(transform.gameObject, 4);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<PlayerController>().Health -= GetComponent<Spitter>().dmg;
            Destroy(transform.gameObject);
            Debug.Log("htting.....");
        }
    }*/
}
