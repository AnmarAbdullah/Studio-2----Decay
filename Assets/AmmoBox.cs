using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    Animation anim;
    public GunController[] gunsAmmo;
    public ParticleSystem ammoEffect;
    public bool isUsed;
    private void Start()
    {
        anim = GetComponent<Animation>();
        //gunsAmmo = gameObject.GetComponents<GunController>();
        gunsAmmo = FindObjectsOfType<GunController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var weapons = GameObject.FindGameObjectsWithTag("Weapon");
            if (Input.GetKeyDown(KeyCode.E) && !isUsed)
            {
                isUsed = true;
                anim.Play();
                foreach(var guns in weapons)
                {
                    guns.GetComponent<GunController>().reservedAmmoCapacity += 60;
                    //guns.reservedAmmoCapacity += 60;
                }
            }
        }
    }
}
