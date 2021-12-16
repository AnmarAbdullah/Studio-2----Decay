using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttacker : MonoBehaviour
{
   public Transform Golem;
    [SerializeField]float speed;
    [SerializeField]float dist;

    Animator anim;
    void Start()
    {
        Golem = GameObject.FindObjectOfType<DefendObject>().transform;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        dist = Vector3.Distance(transform.position, Golem.position);
        
         anim.SetBool("isChasing", true);
         transform.LookAt(Golem);
         transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if (dist <= 6)
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
        if (GetComponent<Target>().isDead == true)
        {
            speed = 0;
        }
    }
}
