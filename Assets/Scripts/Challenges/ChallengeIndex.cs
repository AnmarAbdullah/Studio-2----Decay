using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeIndex : MonoBehaviour
{
    public int nextChallenge;
    public PlayerController player;

    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.ChallengeIndex = nextChallenge;
        }
    }
}
