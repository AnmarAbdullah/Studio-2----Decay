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
    public float challengeTimer;
    public float challengeTimerINT;
    public TextMeshProUGUI challengeTime;
    public GameObject bossWay;
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        healthbar.fillAmount = health / 200;
        challengeTime.text = challengeTimerINT.ToString();
        if(player.ChallengeIndex == 3)
        {
            healthUI.SetActive(true);
            challengeTime.gameObject.SetActive(true);
            challengeTimer += Time.deltaTime;
            challengeTimerINT = Mathf.RoundToInt(challengeTimer);
        }
        else { healthUI.SetActive(false); }
        healthCount.text = health.ToString();
        if(challengeTimer >= 120)
        {
            player.ChallengeIndex = 4;
            bossWay.gameObject.SetActive(true);
            challengeTime.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            health -= 20f;
        }
    }
}
