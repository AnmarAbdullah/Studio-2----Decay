using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    public Transform player;
    public PlayerController morePlayer;
    
    // Patrolling------------------
    public Transform[] points;
    [SerializeField] float speed;
    bool isPatrolling;
    float pointDist;
    [SerializeField]int pointIndex;
    [SerializeField] float pointTimer;
    //Chasing--------------------------
    float dist;
    float range;
    bool isChasing;
    //Attacking-----------------------
    bool isAttacking;


    void Start()
    {
        isPatrolling = true;
        morePlayer = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (isPatrolling)
        {
            Patrolling();
        }
        if(dist <= range)
        {
            isChasing = true;
            isPatrolling = false;
            Chasing();
        }
        if(dist <= 3)
        {
            isChasing = false;
            isPatrolling = false;
            isAttacking = true;
            Attack();
        }
    }

    //Patrolling---------------------------------------------------------
    void Patrolling()
    {
        if(transform.position != points[pointIndex].position)
        {
            pointTimer += Time.deltaTime;
            if(pointTimer >= 5)
            {
                transform.LookAt(points[pointIndex]);
                transform.position = Vector3.MoveTowards(transform.position, points[pointIndex].position, speed * Time.deltaTime);
            }
        }
        else
        {
            pointIndex = (pointIndex + 1) % points.Length;
            pointTimer = 0;
        }
    }
    void Chasing()
    {
        if (isChasing)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    void Attack()
    {
        //play attack animation instantly
        morePlayer.Health -= 40;
    }
    void Alert()
    {
        //happens if the player runs away...get last known location from the chase and go towards it.
    }
}
