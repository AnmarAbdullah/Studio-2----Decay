using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    //public GameObject Explosion Effect later...
    public float explosionForce;
    public float radius;
    void Start()
    {
        Invoke("Explode", 3);
    }

    void Explode()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider near in collider) // (int i=0; i < collider.Length; i++)
        {
            Rigidbody body = near.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.AddExplosionForce(explosionForce, transform.position, radius, 10, ForceMode.Impulse);
                Destroy(transform.gameObject);
            }
        }
        Destroy(gameObject, 0.2f);
    }
}
