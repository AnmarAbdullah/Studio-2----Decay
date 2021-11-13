using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float dmg;

    public float dist;
    public float range;

    public float speed;

    bool isDead;

    public Transform player;
    public PlayerController pplayer;
    public Spawner spawner;

    public Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, player.position);
        if(dist <= range && GetComponent<Target>().isDead == false)
        {
            LookatPlayer();
            Behavior();
            Attack();
        }
        if(dist <= 1.5)
        {
            pplayer.Health -= dmg;
        }
    }

    
    protected virtual void LookatPlayer()
    {
        if (GetComponent<Target>().isDead == false)
        {
            transform.LookAt(player);
        }
    }
    protected virtual void Behavior()
    {
    }
    protected virtual void Attack()
    {
    }

}
