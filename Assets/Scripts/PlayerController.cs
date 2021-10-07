using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity = -9.81f;

    public CharacterController controller;
    public AudioSource walkingSoundEff;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3;

    public bool isGrounded;

    public GameObject crossBow;
    void Start()
    {
        walkingSoundEff = GetComponent<AudioSource>();
    }
    void Update()
    {
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

    }
}
