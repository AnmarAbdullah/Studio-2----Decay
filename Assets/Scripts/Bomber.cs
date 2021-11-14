using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    protected override void Behavior()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, 10);
        foreach (Collider near in collider) // (int i=0; i < collider.Length; i++)
        {
            Rigidbody body = near.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.AddExplosionForce(15, transform.position, 10, 10, ForceMode.Impulse);
            }
        }
        Destroy(gameObject, 0.2f);
    }
}
