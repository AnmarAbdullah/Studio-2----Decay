using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
        
           /* player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            pplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();*/
        
    }
    protected override void Behavior()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        anim.SetBool("isChasing", true);
        if(dist <= 3)
        {
            anim.SetBool("isAttacking", true);
            anim.SetBool("isChasing", false);
            speed = 1;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isChasing", true);
            speed = 4;
        }
        if(GetComponent<Target>().isDead == true)
        {
            speed = 0;
        }
    }
}
