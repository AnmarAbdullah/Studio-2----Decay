using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    // Ability Cooldown System------
    float healCD = 8;
    float nextHeal;

    float GrenadeCD = 1;
    float nextGrenade;

    float stunCD = 3;
    float nextStun;
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
            animate.SetBool("Running", true);
        }
        else if(!isGrounded || !Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            walkingSoundEff.Stop();
            animate.SetBool("Running", false);
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
        if (Time.time > nextHeal)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                isHealing = true;
                nextHeal = Time.time + healCD;
            }
        }
        if (Health >= 300)
        {
            Health = 300;
        }
    }

    private void FixedUpdate()
    {
        if (Time.time > nextGrenade)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                ThrowGrenade();
                nextGrenade = Time.time + GrenadeCD;
            }
        }
        if (Time.time > nextStun)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Stun();
                nextStun = Time.time + stunCD;
            }
        }
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
