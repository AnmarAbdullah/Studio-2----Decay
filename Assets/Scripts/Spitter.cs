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

            var spits = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);

            attacking = true;
            Invoke(nameof(ResetAttack), 1);
            Destroy(spits, 2);
        }
       // Destroy(spits, 3);
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
