using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScareForest : MonoBehaviour
{
    [SerializeField]Animator anim;
    [SerializeField] AudioSource audioS;
    [SerializeField] GameObject obj;
    

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Zombie());
    }

    IEnumerator Zombie()
    {
        anim.SetBool("move", true);
        audioS.Play();
        yield return new WaitForSeconds(1.5f);
        Destroy(obj);
    }


}

