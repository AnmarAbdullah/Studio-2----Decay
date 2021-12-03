using UnityEngine;
using UnityEngine.UI;

public class playSFX : MonoBehaviour
{
    public AudioSource sound;
    public AudioSource music;
    public AudioSource stopMusic;
    public GameObject destroyTrigger;
    public Image text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            if (sound != null)
            {
                sound.Play();
            }
            if (music != null)
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
                Destroy(destroyTrigger);
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
