using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponsUI : MonoBehaviour
{
    [SerializeField] int gunIndex;
    public Image[] GunImage;
    public Text[] clipSize;
    public Text[] Ammo;
    //public Text[] ammoSize;
    public GunSwitcher gunChosen;
    public GunController[] clip;


    void Start()
    {
        gunChosen = FindObjectOfType<GunSwitcher>();
       // clip[clip.Length] = FindObjectOfType<GunController>();
    }
    void Update()
    {
        gunIndex = gunChosen.selectedWeapon;

        for (int i = 0; i < GunImage.Length; i++)
        {
            if(gunIndex == i)
            {
                GunImage[i].gameObject.SetActive(true);
                clipSize[i].text = clip[i].clipSize.ToString();
            }
            else
            {
                GunImage[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < clipSize.Length; i++)
        {
            if(gunIndex == i)
            {
                clipSize[i].gameObject.SetActive(true);
                clipSize[i].text = clip[i].ammoInClip.ToString();
            }
            else
            {
                clipSize[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < Ammo.Length; i++)
        {
            if (gunIndex == i) 
            {
                Ammo[i].gameObject.SetActive(true);
                Ammo[i].text = clip[i].ammoInReserve.ToString();    
            }
            else
            {
                Ammo[i].gameObject.SetActive(true);
            }
        }

    }

    void ActivateWeaponPic() 
    {
        //chosenGun[gunIndex].gameObject.SetActive(true);
    }
}
