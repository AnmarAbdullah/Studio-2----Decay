using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform player;
    public GameObject projectile;
    bool projectiling;
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Projectilee();
    }
    public void Projectilee()
    {
        // mouth.transform.LookAt(seekObject);
        
        
            if (!projectiling) {
            
                transform.LookAt(player);
                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.up * 3, ForceMode.Impulse);
                rb.AddForce(transform.forward * 35, ForceMode.Impulse);
                projectiling = true;
                Invoke(nameof(ResetAttack), 0.2f);
            }
        
    }
    public void ResetAttack()
    {
        projectiling = false;
    }
}
