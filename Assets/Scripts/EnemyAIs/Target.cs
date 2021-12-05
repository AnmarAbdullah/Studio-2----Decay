using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50;
    public bool isDead;
    Animator anim;
    [SerializeField]int randomDeath;

    //public GameObject ammo;
    int randomAmmoDrop;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            //randomAmmoDrop = Random.Range(3, 6);
            //if (randomAmmoDrop <= 3)
            //{
                //DropAmmo();
            //}
        }
    }
    public void Die()
    {
        isDead = true;
        randomDeath = Random.Range(1, 3);
        //GetComponent<Enemy>().speed = 0;
        GetComponent<Rigidbody>().isKinematic = true;
        if (isDead && randomDeath == 1)
        {
            anim.SetBool("isDeadFront", true);
        }
        if (isDead && randomDeath == 2)
        {
            anim.SetBool("isDeadBack", true);
        }
        anim.SetInteger("State", 3);
        Destroy(gameObject, 10);
    }

    //void DropAmmo()
    //{
    //    GameObject Ammo = Instantiate(ammo, transform.position, Quaternion.identity);
    //}
}
