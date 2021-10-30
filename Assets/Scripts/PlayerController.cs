using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : damagePlayer
{
    public float speed;
    public float gravity = -9.81f;

    public CharacterController controller;
    public AudioSource walkingSoundEff;
    public Camera camera;
    public GameObject Grenade;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3;

    public float Health = 300;
    public float healingTime;
    bool isHealing = false;

    public int ChallengeIndex;

    // Ability Cooldown & amount System------ NEEDS REWORK
    float healCD = 8;
    float nextHeal;
    public float heals;
    public Text healsAmount;

    float GrenadeCD = 1;
    float nextGrenade;
    public float grenades;
    public Text grenadesAmount;

    public float stunCD = 7;
    public float nextStun;
    public Image stunCool;
    public Text stunclDnUI;
    // ------------------------------


    public bool isGrounded;

    void Start()
    {       
        walkingSoundEff = GetComponent<AudioSource>();
    }
    void Update()
    {
        // player movement system:
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") && isGrounded)
        {
            walkingSoundEff.Play();
            
        }
        else if(!isGrounded || !Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            walkingSoundEff.Stop();
            
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;

        controller.Move(movement * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
           velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

      // health system :
        StemShot();
       /* if (Time.time > nextHeal)
        {
            if (Input.GetKeyDown(KeyCode.H) & heals > 0)
            {
                isHealing = true;
                nextHeal = Time.time + healCD;
                heals--;
            }
        }
        if (Health >= 300)
        {
            Health = 300;
        }
       */

        grenadesAmount.text = grenades.ToString();
        healsAmount.text = heals.ToString();
        stunclDnUI.text = nextStun.ToString();

       // stunCool.fillAmount = nextStun = stunCD;
    }

    private void FixedUpdate()
    {
        /*if (Time.time > nextGrenade)
        {
            if (Input.GetKeyDown(KeyCode.G) & grenades > 0)
            {
                ThrowGrenade();
                nextGrenade = Time.time + GrenadeCD;
                grenades--;
            }
        }
        if (Time.time > nextStun)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Stun();
                nextStun = Time.time + stunCD;
            }
        }*/
    }
    void StemShot() // Ability 1
    {
        if (isHealing)
        {
            Health += 0.6f;
            healingTime += Time.deltaTime;
            if(healingTime >= 3)
            {
                isHealing = false;
                healingTime = 0;
            }
        }
    }

    void ThrowGrenade() // Ability 2
    {
        Rigidbody rb = Instantiate(Grenade, camera.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 25, ForceMode.Impulse);
    }


    void Stun() // Ability 3
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, 10);
        foreach (Collider near in collider) // (int i=0; i < collider.Length; i++)
        {
            Rigidbody body = near.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.AddExplosionForce(15, transform.position, 10, 10, ForceMode.Impulse);
            }
        }
    }

    
}
