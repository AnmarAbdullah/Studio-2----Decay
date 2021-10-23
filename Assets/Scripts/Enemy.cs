using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float dmg;

    public float dist;
    public float range;

    public float speed;

    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, player.position);
        if(dist <= range)
        {
            LookatPlayer();
            Behavior();
            Attack();
        }
    }

    protected virtual void LookatPlayer()
    {
        transform.LookAt(player);
    }
    protected virtual void Behavior()
    {
    }
    protected virtual void Attack()
    {
    }
}
