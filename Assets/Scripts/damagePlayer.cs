using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth = 100;
    public int damage;

    private void Start()
    {
        print(playerHealth);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth -= damage;
            print("dummy" + playerHealth);
        }
        
    }
}
