using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekObject : MonoBehaviour
{
    public Transform player;
    public PlayerController pplayer;
    [SerializeField] float maxVelocity = 3;
    Vector3 velocity;
    [SerializeField] float max_force = 3;
    [SerializeField] float mass = 3;
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").transform;
        this.pplayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        velocity = player.transform.position - transform.position;
        velocity = velocity * maxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (pplayer.ChallengeIndex == 4)
        {
            var desired_velocity = player.position - transform.position;
            desired_velocity = desired_velocity.normalized * maxVelocity;


            var steering = desired_velocity - velocity;
            steering = Vector3.ClampMagnitude(steering, max_force);
            steering = steering / mass;

            velocity = Vector3.ClampMagnitude(velocity += steering, maxVelocity);
            transform.forward = transform.position += velocity * Time.deltaTime;
        }
    }
}
