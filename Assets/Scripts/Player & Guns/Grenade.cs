using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    //public GameObject Explosion Effect later...
    public float explosionForce;
    public float radius;
    public ParticleSystem explosionVFX;
    void Start()
    {
        Invoke("Explode", 3);
    }

    void Explode()
    {
        explosionVFX.Play();
        Collider[] collider = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider near in collider) 
        {
            Rigidbody body = near.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.AddExplosionForce(explosionForce, transform.position, radius, 10, ForceMode.Impulse);
            }
            Target bodies = near.GetComponent<Target>();
            if(bodies != null)
            {
                bodies.Die();
            }
        }
        Destroy(gameObject, 0.5f);
    }
}
