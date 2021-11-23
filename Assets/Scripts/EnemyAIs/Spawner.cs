using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{
    public GameObject[] Enemies;
    public GameObject Zombie;
    public float timer;
    public float nextSpawn = 5;
    public float enemyTimer;
    public float nextEnemy = 3;
    public int myChallengeIndex;

    public int zombieLimit;
    protected override void spawnEnemies()
    {
        Debug.Log("Sspawninggg");
        if (myChallengeIndex == pplayer.ChallengeIndex && zombieLimit <65)
        { 
            timer += Time.deltaTime;
            if (timer > nextSpawn)
            {
                Rigidbody rb = Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                timer = 0;
                zombieLimit += 1;
            }
            enemyTimer += Time.deltaTime;
            if (enemyTimer > nextEnemy)
            {
                Rigidbody rb = Instantiate(Zombie, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                enemyTimer = 0;
                zombieLimit += 1;
            }
        }
    }
}
