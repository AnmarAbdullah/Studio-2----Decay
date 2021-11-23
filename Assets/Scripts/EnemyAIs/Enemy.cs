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

    public Transform Player;
    public PlayerController pplayer;
    public Spawner spawner;
    public Animator anim;
    void Start()
    {
        this.Player = GameObject.FindWithTag("Player").transform;
        this.pplayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>(); 

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, Player.position);
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
        if (dist <= range)
        {
            spawnEnemies();
        }
        spawnEnemies();
    }

    
    protected virtual void LookatPlayer()
    {
        if (GetComponent<Target>().isDead == false)
        {
            transform.LookAt(Player);
        }
    }
    protected virtual void Behavior()
    {
    }
    protected virtual void Attack()
    {
    }
    protected virtual void spawnEnemies()
    {
    }

}
