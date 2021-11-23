using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{
    public GameObject[] Enemies;
    public GameObject Zombie;
    public float timer;
    public float nextSpawn = 3;
    public float enemyTimer;
    public float nextEnemy = 3;
    public int myChallengeIndex;

    protected override void spawnEnemies()
    {
        Debug.Log("Sspawninggg");
        //enemyTimer += Time.deltaTime;
        if (myChallengeIndex == pplayer.ChallengeIndex)
        {
            enemyTimer += Time.deltaTime;
            if (enemyTimer > nextEnemy)
            {
                Rigidbody rb = Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                enemyTimer = 0;
            }
            timer += Time.deltaTime;
            if (timer > nextSpawn && myChallengeIndex == pplayer.ChallengeIndex)
            {
                Rigidbody rb = Instantiate(Zombie, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                timer = 0;
            }
        }
    }
}
