using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playSFX : MonoBehaviour
{
    public AudioSource sound;
    public AudioSource music;
    public AudioSource stopMusic;
    public GameObject destroyTrigger;
    public Image text;
    public TextMeshProUGUI subtitle;
    public bool hit;
    public float subtitleTimer;
    public float subtitleEnd;

     void Update()
    {
        if (hit)
        {
            subtitle.gameObject.SetActive(true);
            subtitleTimer += Time.deltaTime;
            if (subtitleTimer >= subtitleEnd)
            {
                subtitle.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // hit = true;
            /* if (hit)
             {
                 subtitle.gameObject.SetActive(true);
                 subtitleTimer += Time.deltaTime;
                 if(subtitleTimer >= subtitleEnd)
                 {
                     subtitle.gameObject.SetActive(false);
                 }
             }*/

            if (!hit) 
            { 
                if (sound != null && !hit)
                {
                    sound.Play();
                }
                if (music != null && !hit)
                {
                    music.Play();
                }

                if (text != null)
                {
                    text.enabled = true;
                }
                if (stopMusic != null)
                {
                    Destroy(stopMusic);
                }
                if (GameObject.FindGameObjectWithTag("Destroy"))
                {
                    // Destroy(destroyTrigger);
                }
                hit = true;
            }
        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (!GameObject.FindGameObjectWithTag("Destroy"))
        {
            music.Stop();
        }

    }

}
