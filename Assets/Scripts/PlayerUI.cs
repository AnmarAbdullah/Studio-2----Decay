using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    //float currentMeter;
   // float MAXMeter = 20000;
    
    float currentHealth;
    float MaxHealth = 300;

    //[SerializeField]int gunIndex;

   // public Image MeterUI;
    public Image HealthUI;
    
    //public Image[] chosenGun;

    //public GunSwitcher gunChosen;
    [SerializeField] PlayerController player;
   // [SerializeField] FourPlatformsTask meter;
   // GunSwitcher switcher;


    void Start()
    {
        //MeterUI = GetComponent<Image>();
        HealthUI = GetComponent<Image>();

        // switcher = FindObjectOfType<GunSwitcher>();

       // gunChosen = FindObjectOfType<GunSwitcher>();
        //meter = FindObjectOfType<FourPlatformsTask>();
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //gunIndex = gunChosen.selectedWeapon;
        
        
        /*currentMeter = meter.Meter;
        MeterUI.fillAmount = 0.084f;*/

        currentHealth = player.Health;
        HealthUI.fillAmount = currentHealth / MaxHealth;

        /*switch (gunIndex)
        {
            case 0:
                chosenGun[gunIndex].gameObject.SetActive(true);
                break;
            case 1:
                chosenGun[gunIndex].gameObject.SetActive(true);
                break;
            case 2:
                chosenGun[gunIndex].gameObject.SetActive(true);
                break;
            case 3:
                chosenGun[gunIndex].gameObject.SetActive(true);
                break;
            default:
                    chosenGun[chosenGun.Length].gameObject.SetActive(false);
                break;
        }*/
    }
}
