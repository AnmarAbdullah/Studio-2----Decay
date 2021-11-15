using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int playerHealth = 300;
    public int dmg;

    public float dist;
    public float range;

    public float speed;

    bool isDead;

    public Transform player;
    public PlayerController pplayer;
    public Spawner spawner;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth -= dmg;
            print("dummy" + playerHealth);
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
