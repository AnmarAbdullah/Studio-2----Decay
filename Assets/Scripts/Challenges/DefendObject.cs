using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefendObject : MonoBehaviour
{
    public float health = 10000;
    public GameObject healthUI;
    public Image healthbar;
    public TextMeshProUGUI  healthCount;
    PlayerController player;
    public float challengeTimer = 120;
    public float challengeTimerINT;
    public TextMeshProUGUI challengeTime;
    public GameObject bossWay;
    public GameObject bossGate;
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        challengeTimer = 120;
    }
    void Update()
    {
        healthbar.fillAmount = health / 300;
        challengeTime.text = challengeTimerINT.ToString();
        if(player.ChallengeIndex == 3)
        {
            healthUI.SetActive(true);
            challengeTime.gameObject.SetActive(true);
            challengeTimer -= Time.deltaTime;
            challengeTimerINT = Mathf.RoundToInt(challengeTimer);
        }
        else { healthUI.SetActive(false); }
        healthCount.text = health.ToString();
        if(challengeTimer <= 0)
        {
            player.ChallengeIndex = 4;
            bossWay.gameObject.SetActive(true);
            challengeTime.gameObject.SetActive(false);
            bossGate.gameObject.SetActive(false);
        }
        if(health <= 0)
        {
            player.playerLives -= 1;
            health = 300;
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            health -= 10f;
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            health -= 30f;
        }
    }
}
