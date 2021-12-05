using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeIndex : MonoBehaviour
{
    public int nextChallenge;
    public PlayerController player;
    DefendObject golem;
    float radius = 10000;
    public AudioSource bossbattle;

    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        golem = FindObjectOfType<DefendObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.ChallengeIndex = nextChallenge;
            Collider[] collider = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider near in collider)
            {
                Target bodies = near.GetComponent<Target>();
                if (bodies != null)
                {
                    bodies.Die();
                }
            }
            if (player.ChallengeIndex ==4 && golem.challengeTimer >= 119)
            {
                player.transform.position = new Vector3(530, 132, 1435);
            }
        }
    }
}
