using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    Animation anim;
    public GunController[] gunControllers;
    public ParticleSystem ammoEffect;
    public bool isUsed;
    PlayerController player;

    private void Start()
    {
        anim = GetComponent<Animation>();
        //gunsAmmo = gameObject.GetComponents<GunController>();
        gunControllers = FindObjectsOfType<GunController>(true);
        this.player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //var weapons = GameObject.FindGameObjectsWithTag("Weapon");
            if (Input.GetKeyDown(KeyCode.E) && !isUsed)
            {
                ammoEffect.gameObject.SetActive(false);
                isUsed = true;
                anim.Play();
                foreach(GunController gun in gunControllers)
                {
                    gun.ammoInReserve += 100;
                    Debug.Log(gun.gameObject.name);
                }
                player.heals += 2;
                player.grenades += 2;

            }
        }
    }
}
