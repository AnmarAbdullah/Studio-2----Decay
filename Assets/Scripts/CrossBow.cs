using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public Animator shootingAnim;
    public GameObject Arrow;
    [SerializeField] bool shot = false;
    [SerializeField] float shootDelay;
    //will add attack speed soon

   
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (!shot)
            {
                Rigidbody rb = Instantiate(Arrow, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 32, ForceMode.Impulse);
                shootingAnim.Play("Shoot");
                shot = true;
            }
        }
        if (shot) { shootDelay += Time.deltaTime; }
        if (shootDelay >= 0.75f)
        {
            shot = false;
            Debug.Log("hi");
            Debug.Log(shootDelay);
            shootDelay = 0;
        }

    }
}
