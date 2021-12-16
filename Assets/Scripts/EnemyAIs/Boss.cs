using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject projectile;
    public Transform mouth;
    public Transform[] eyes;
    public GameObject Zombie;
    public Transform seekObject;
    Transform player;
    PlayerController pplayer;
    bool projectiling;
    bool zombie;
    public bool[] Behaviour;
    public float timer;
    int chosenPhase;
    public Target target;
    public Image bossHealth;
    public GameObject BossHealthUI;
    public GunController[] gunControllers;
    /*float bossMaxHealth = 3000;
    float currenthealth;*/
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").transform;
        gunControllers = FindObjectsOfType<GunController>(true);
        this.pplayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

    void Update()
    {
        //mouth.transform.LookAt(seekObject);
        bossHealth.fillAmount = target.health / 3000;

        if (pplayer.ChallengeIndex == 4)
        {
            timer += Time.deltaTime;
            BossHealthUI.gameObject.SetActive(true);
            //mouth.transform.LookAt(seekObject);
            for (int i = 0; i < eyes.Length; i++)
            {
                eyes[i].transform.LookAt(seekObject);
            }

            if (timer >= 5)
            {
                chosenPhase = Random.Range(0, Behaviour.Length);
                for (int i = 0; i < Behaviour.Length; i++)
                {
                    if (chosenPhase == i)
                    {
                        Behaviour[i] = true;
                    }
                    else
                    {
                        Behaviour[i] = false;
                    }
                }
                timer = 0;
            }
        }
        laserEyes();
        Projectile();
        ZombieSpit();

        if(target.health <= 0)
        {
            player.transform.position = new Vector3(434, 151, 1330);
            pplayer.ChallengeIndex = 1;
            target.health = 1;
            BossHealthUI.gameObject.SetActive(false);
            foreach (GunController gun in gunControllers)
            {
                gun.ammoInReserve += 10000;
                Debug.Log(gun.gameObject.name);
            }
        }
        /*if (!Behaviour[0])
        {
            for (int i = 0; i < eyes.Length; i++)
            {
                eyes[i].gameObject.SetActive(false);
            }
        }*/
    }

    public void laserEyes()
    {
        if (Behaviour[0])
        {
            for (int i = 0; i < eyes.Length; i++)
            {
                eyes[i].gameObject.SetActive(true);
                eyes[i].transform.LookAt(seekObject);

            }
        }
        else
        {
            for (int i = 0; i < eyes.Length; i++)
            {
                eyes[i].gameObject.SetActive(false);
                eyes[i].transform.LookAt(seekObject);

            }
        }
    }

    public void Projectile()
    {
       // mouth.transform.LookAt(seekObject);
        if (Behaviour[1])
        {
            mouth.gameObject.SetActive(true);
        }
        else
        {
            mouth.gameObject.SetActive(false);

        }
    }
    public void ResetAttack()
    {
        projectiling = false;
    }

    public void ZombieSpit()
    {
        if (Behaviour[2])
        {
            if (!zombie)
            {
                Rigidbody rbb = Instantiate(Zombie, mouth.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rbb.AddForce(transform.forward * 15, ForceMode.Impulse);
                zombie = true;
                Invoke(nameof(ResetAttack), 1f);
            }
        }
    }
    public void ZResetAttack()
    {
        zombie = false;
    }
}

