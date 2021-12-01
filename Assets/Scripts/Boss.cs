using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject projectile;
    public Transform mouth;
    public Transform[] eyes;
    public GameObject Zombie;
    public Transform seekObject;
    Transform player;
    bool projectiling;
    bool zombie;
    public bool[] Behaviour;
    public float timer;
    int chosenPhase;
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        mouth.transform.LookAt(player);
        for (int i = 0; i < eyes.Length; i++)
        {
            eyes[i].transform.LookAt(seekObject);
        }
        timer += Time.deltaTime;
        
        if (timer >= 4)
        {
            chosenPhase = Random.Range(0, Behaviour.Length);
            for (int i = 0; i < Behaviour.Length; i++)
            {
                if (chosenPhase == i)
                {
                    Behaviour[i] = true;
                }
                else
                {
                    Behaviour[i] = false;
                }
            }
            timer = 0;
        }
        laserEyes();
        Projectile();
        ZombieSpit();
        /*if (!Behaviour[0])
        {
            for (int i = 0; i < eyes.Length; i++)
            {
                eyes[i].gameObject.SetActive(false);
            }
        }*/
    }

    public void laserEyes()
    {
        if (Behaviour[0])
        {
            for (int i = 0; i < eyes.Length; i++)
            {
                eyes[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < eyes.Length; i++)
            {
                eyes[i].gameObject.SetActive(false);
            }
        }
    }

    public void Projectile()
    {
        mouth.transform.LookAt(player);
        if (Behaviour[1])
        {
            if (!projectiling)
            {
                Rigidbody rb = Instantiate(projectile, mouth.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 15, ForceMode.Impulse);
                projectiling = true;
                Invoke(nameof(ResetAttack), 0.05f);
            }
        }
    }
    public void ResetAttack()
    {
        projectiling = false;
    }

    public void ZombieSpit()
    {
        if (Behaviour[2])
        {
            if (!zombie)
            {
                Rigidbody rbb = Instantiate(Zombie, mouth.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rbb.AddForce(transform.forward * 15, ForceMode.Impulse);
                zombie = true;
                Invoke(nameof(ResetAttack), 3f);
            }
        }
    }
    public void ZResetAttack()
    {
        zombie = false;
    }
}

