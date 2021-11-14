using UnityEngine;
using System.Collections;

public class GunSwitcher : MonoBehaviour
{
    public int selectedWeapon = 0;
    public int previousSelectedWeapon;
    public GunController[] guns;
    
    
    

    void Start()
    {
        guns = GetComponentsInChildren<GunController>(true);
        SelectWeapon();
        
    }


    void Update()
    {

        previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= guns.Length - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = guns.Length - 1;
            else
                selectedWeapon--;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
    void SelectWeapon()
    {
        //bool sniper = GameObject.FindGameObjectWithTag("Sniper");

        guns[previousSelectedWeapon].gameObject.SetActive(false);
        guns[selectedWeapon].gameObject.SetActive(true);

        guns[selectedWeapon].currentRotation = guns[previousSelectedWeapon].currentRotation;

        if (guns[selectedWeapon].name.Contains("sniper1") == false)
        {
            GetComponent<GunController>().UnScoped();
            GetComponent<GunController>().scopeOverlay.SetActive(false);
        }

        //if (sniper == false)
        //{
        //    GetComponent<GunController>().UnScoped();
        //}



    }
}
