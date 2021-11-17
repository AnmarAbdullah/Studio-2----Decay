using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    
    float currentHealth;
    float MaxHealth = 300;


    public Image HealthUI;
    public RawImage healthWarn;
    public Image lowHealthOverlay;
    public float timer;
    

    [SerializeField] PlayerController player;


    void Start()
    {;
        HealthUI = GetComponent<Image>();
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        currentHealth = player.Health;
        HealthUI.fillAmount = currentHealth / MaxHealth;

        /*if(currentHealth<= 170)
        {
            timer += Time.deltaTime;
            if (timer <= 2)
            {

            }
        }*/
        if (player.Health <= 150/*player.Health / 2*/)
        {
            Warning();
        }
        else if (healthWarn.enabled && lowHealthOverlay.enabled)
        {
            healthWarn.gameObject.SetActive(false);
            lowHealthOverlay.gameObject.SetActive(false);
        }

    }

    public void Warning()
    {
        lowHealthOverlay.gameObject.SetActive(true);
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            healthWarn.gameObject.SetActive(true);
        }
        if (timer >= 1)
        {
            healthWarn.gameObject.SetActive(false);
            timer = 0;
        }
        /*else
        {
            timer = 0;
        }*/
    }
}
