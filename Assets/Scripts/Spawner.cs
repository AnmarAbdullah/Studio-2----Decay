using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{
    public GameObject[] Enemies;
    public float timer;
    public float nextSpawn = 3;
    public int myChallengeIndex;

    protected override void Behavior()
    {
        timer += Time.deltaTime;
        if (timer > nextSpawn && myChallengeIndex == pplayer.ChallengeIndex)
        {
            Rigidbody rb = Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            timer = 0;
        }
    }
}
