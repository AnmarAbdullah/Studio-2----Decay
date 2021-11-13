using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    float animTimer;
    bool isChasing = true;
    protected override void Attack()
    {
        if (isChasing) {transform.Translate(Vector3.forward * speed * Time.deltaTime); }
    }
    protected override void Behavior()
    {      
        if (dist <= 4)
        {
            isChasing = false;
            animTimer += Time.deltaTime;
            if (animTimer > 1)
            {
                anim.SetBool("Exploded", true);
                Collider[] collider = Physics.OverlapSphere(transform.position, 10);
                foreach (Collider near in collider) // (int i=0; i < collider.Length; i++)
                {
                    Rigidbody body = near.GetComponent<Rigidbody>();
                    if (body != null)
                    {
                        body.AddExplosionForce(15, transform.position, 10, 10, ForceMode.Impulse);
                    }
                    Destroy(gameObject, 0.2f);
                }
                if(dist <= 7) { pplayer.Health -= dmg; }
            }
            anim.SetBool("Exploded", true);

        }
    }
}
