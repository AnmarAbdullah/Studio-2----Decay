using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    [SerializeField]float animTimer;
    bool isChasing = true;
    public ParticleSystem explosionVFX;
    [SerializeField] bool gonnaExplode;
    protected override void Attack()
    {
        if (isChasing) {transform.Translate(Vector3.forward * speed * Time.deltaTime); }
    }
    void FixedUpdate()
    {
        /*if (gonnaExplode)
        {
            animTimer += Time.deltaTime;
        }*/
    }
    protected override void Behavior()
    {    /// The reason for the huge amount of if statements here is because i wanted to call a function
         /// at the end of an animation, so I had to use booleans and if statements a lot here...
        /*if (gonnaExplode)
        {
            animTimer += Time.deltaTime;
        }*/
        if (dist <= 4||gonnaExplode)
        {
            gonnaExplode = true;
           // if (gonnaExplode)
            //{
                isChasing = false;
               // animTimer += Time.deltaTime;
                if (animTimer >= 1)
                {
                    explosionVFX.Play();
                    anim.SetBool("Exploded", true);
                    Collider[] collider = Physics.OverlapSphere(transform.position, 10);
                    foreach (Collider near in collider) // (int i=0; i < collider.Length; i++)
                    {
                        Rigidbody body = near.GetComponent<Rigidbody>();
                        if (body != null)
                        {
                            body.AddExplosionForce(15, transform.position, 10, 10, ForceMode.Impulse);
                        }
                    }
                    if (dist <= 7) { pplayer.Health -= dmg; }
               }
            //}
            anim.SetBool("Exploded", true);
            Destroy(transform.gameObject, 1.5f);
        }
        if (gonnaExplode)
        {
            animTimer += Time.deltaTime;
        }
    }
}
