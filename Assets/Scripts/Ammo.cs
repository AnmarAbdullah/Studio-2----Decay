using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    Animation anim;
    public PlayerController player;
    public GunController[] addAmmo;
    void Start()
    {
        anim = GetComponent<Animation>();
        this.player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        //addAmmo = FindObjectOfType<GunController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play();
                for (int i = 0; i < addAmmo.Length; i++)
                {
                    addAmmo[i].reservedAmmoCapacity += 200;
                }
            }
        }
    }
}
