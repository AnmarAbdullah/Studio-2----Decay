using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponsUI : MonoBehaviour
{
    [SerializeField] int gunIndex;
    public Image[] GunImage;
    public GunSwitcher gunChosen;


    void Start()
    {
        gunChosen = FindObjectOfType<GunSwitcher>();
    }
    void Update()
    {
        gunIndex = gunChosen.selectedWeapon;

        for (int i = 0; i < GunImage.Length; i++)
        {
            if(gunIndex == gunChosen.selectedWeapon)
            {
                GunImage[gunChosen.selectedWeapon].gameObject.SetActive(true);
            }
            else
            {
                GunImage[i].gameObject.SetActive(false);
            }
        }
        /*if(gunIndex == gunChosen.selectedWeapon)
        {
            GunImage[gunIndex].gameObject.SetActive(true);
        }*/
        

        /*for (int i = 0; i < chosenGun.Length; i++)
        {
            chosenGun[i].gameObject.SetActive(i >= chosenGun.Length - 1);
        }*/

        /*switch (gunIndex)
        {
            case 0:
                ActivateWeaponPic();
                    break;
            case 1:
                ActivateWeaponPic();
                    break;
            case 2:
                ActivateWeaponPic();
                    break;
            case 3:
                ActivateWeaponPic();
                    break;
            default:
                chosenGun[chosenGun.Length].gameObject.SetActive(false);
                break;
        }*/
    }

    void ActivateWeaponPic() 
    {
        //chosenGun[gunIndex].gameObject.SetActive(true);
    }
}
