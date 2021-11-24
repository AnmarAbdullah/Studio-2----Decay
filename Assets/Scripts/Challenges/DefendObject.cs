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
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        healthbar.fillAmount = health / 10000;
        if(player.ChallengeIndex == 2)
        {
            healthUI.SetActive(true);
        }
        else { healthUI.SetActive(false); }
        healthCount.text = health.ToString();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            health -= 20f;
        }
    }
}
