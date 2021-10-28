using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter : Enemy
{
    public GameObject Projectile;
    bool attacking;
    
    protected override void Attack()
    {
        if (!attacking)
        {
            Rigidbody rb = Instantiate(Projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 15, ForceMode.Impulse);

            attacking = true;
            Invoke(nameof(ResetAttack), 1);
        }
    }
    protected override void Behavior()
    {
        if(dist <= 7)
        {
            transform.Translate(Vector3.back * 10 * Time.deltaTime);
        }
    }
    private void ResetAttack()
    {
        attacking = false;
    }
}
