using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter : Enemy
{
    public GameObject Projectile;
    bool attacking;
    Animator anim;

    private void Start()
    {
      
        
        anim = GetComponent<Animator>();

         this.Player = GameObject.FindWithTag("Player").transform;
         this.pplayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
    }
    protected override void LookatPlayer()
    {
        transform.LookAt(Player);
        if (dist >= 8)
        {
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);
            anim.SetInteger("State", 0);
        }
    }
    protected override void Attack()
    {
        if (!attacking)
        {
            Rigidbody rb = Instantiate(Projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 15, ForceMode.Impulse);

            anim.SetInteger("State", 2);
            attacking = true;
            Invoke(nameof(ResetAttack), 2);
            //Destroy(spits, 2);
        }
       // Destroy(spits, 3);
    }
    protected override void Behavior()
    {
        if(dist <= 7)
        {
            transform.Translate(Vector3.back * 10 * Time.deltaTime);
            anim.SetInteger("State", 1);
        }
    }
    private void ResetAttack()
    {
        attacking = false;
    }
}
