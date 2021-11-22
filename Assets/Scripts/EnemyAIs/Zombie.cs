using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : Enemy
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        this.Player = GameObject.FindWithTag("Player").transform;
        this.pplayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    protected override void Behavior()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        anim.SetBool("isChasing", true);
        if(dist <= 3)
        {
            anim.SetBool("isAttacking", true);
            anim.SetBool("isChasing", false);
            speed = 0.5f;
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
