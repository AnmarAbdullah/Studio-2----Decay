using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumptrigger : MonoBehaviour
{
    public AudioSource scream;
    public GameObject playercam;
    public GameObject jumpCam;
    public GameObject flickerImg;
    public GameObject destroy;

    private void OnTriggerEnter(Collider other)
    {
        scream.Play();
        jumpCam.SetActive(true);
        playercam.SetActive(false);
        flickerImg.SetActive(true);
        StartCoroutine(EndJump());
        
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2f);
        playercam.SetActive(true);
        jumpCam.SetActive(false);
        flickerImg.SetActive(false);
        if (GameObject.FindGameObjectWithTag("Destroy"))
        {
            Destroy(destroy);
        }

    }
}
