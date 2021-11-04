using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDies : damagePlayer
{
    private void Update()
    {
        if (playerHealth < 0)
        {
            Destroy(GameObject.FindWithTag ("Player"));
        }
    }
}
