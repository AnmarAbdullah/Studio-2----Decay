using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public GameObject credits;
    public TextMeshProUGUI creditsSubtitle;
    public AudioSource vo17;
    public AudioSource creditsGrowl;
    public AudioSource creditsMusic;
    //[SerializeField] GameObject destroyTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            credits.gameObject.SetActive(true);
        }

        

        StartCoroutine(EndCredits());
    }

    IEnumerator EndCredits()
    {
        //Destroy(destroyTrigger);
        vo17.Play();
        creditsSubtitle.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        creditsSubtitle.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        creditsGrowl.Play();
        yield return new WaitForSeconds(1.5f);
        creditsMusic.Play();
        yield return new WaitForSeconds(15.5f);
        SceneManager.LoadScene("mainMenu");
    }
}
