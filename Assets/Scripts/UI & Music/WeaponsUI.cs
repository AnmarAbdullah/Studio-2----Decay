using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponsUI : MonoBehaviour
{
    [SerializeField] int gunIndex;
    public Image[] GunImage;
    public Text[] clipSize;
    public Text[] inClip;
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
                inClip[i].gameObject.SetActive(true);
                inClip[i].text = clip[i].reservedAmmoCapacity.ToString();
            }
            else
            {
                clipSize[i].gameObject.SetActive(false);
                inClip[i].gameObject.SetActive(false);
            }
        }

    }

    void ActivateWeaponPic() 
    {
        //chosenGun[gunIndex].gameObject.SetActive(true);
    }
}
