using UnityEngine;

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
        //int i = 0;

        //foreach (Transform weapon in transform)
        //{
        //    if (i == selectedWeapon)
        //    {
        //        weapon.gameObject.SetActive(true);
        //    }

        //    else
        //    {
        //        weapon.gameObject.SetActive(false);
        //        weapon.GetComponent<GunController>().UnScoped();
        //    } 

        //    i++;
        //}

        guns[previousSelectedWeapon].gameObject.SetActive(false);
        guns[selectedWeapon].gameObject.SetActive(true);

        guns[selectedWeapon].currentRotation = guns[previousSelectedWeapon].currentRotation;

        if (guns[selectedWeapon] != GetComponent<GunController>().isSniper)
        {
            GetComponent<GunController>().UnScoped();
        }
    }
}
