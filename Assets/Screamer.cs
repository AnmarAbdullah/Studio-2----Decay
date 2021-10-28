using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : Enemy
{

    [SerializeField] float effectTimer;
    bool isScreaming = false;
    protected override void Behavior()
    {
        if(dist <= 20)
        {
            speed = 0;
            isScreaming = true;
        }
    }
    protected override void Attack()
    {
        if (isScreaming)
        {
            //play scream audio
            //visual effects for scream
            spawner.nextSpawn = 1;
        }
        effectTimer+=Time.deltaTime;
        if (effectTimer >= 8)
        {
            spawner.nextSpawn = 3;
            effectTimer = 0;
            isScreaming = false;
        }
    }
}
