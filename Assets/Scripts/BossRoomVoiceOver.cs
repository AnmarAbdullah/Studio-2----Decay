using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossRoomVoiceOver : MonoBehaviour
{
    public AudioSource vo14;
    public AudioSource vo15;
    public AudioSource vo16;

    public TextMeshProUGUI subtitleVO14;
    public TextMeshProUGUI subtitleVO15;
    public TextMeshProUGUI subtitleVO16;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartBossDialogue());
        }
        
    }

    IEnumerator StartBossDialogue()
    {
        vo14.Play();
        subtitleVO14.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        subtitleVO14.gameObject.SetActive(false);
        yield return new WaitForSeconds(20f);
        vo15.Play();
        subtitleVO15.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        subtitleVO15.gameObject.SetActive(false);
        yield return new WaitForSeconds(20f);
        vo16.Play();
        subtitleVO16.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        subtitleVO16.gameObject.SetActive(false);
    }





}
