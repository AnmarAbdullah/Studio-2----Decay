using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity = -14;

    public int playerLives = 5;

    public CharacterController controller;
    public AudioSource walkingSoundEff;
    public Camera camera;
    public GameObject Grenade;
    public TextMeshProUGUI livesCount;
    public ParticleSystem healVFX;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 5;

    public float Health = 300;
    public float healingTime;
    bool isHealing = false;

    public int ChallengeIndex;

    // Ability Cooldown & amount System------ NEEDS REWORK    
    public float heals;
    public Text healsAmount;

    public float grenades;
    public Text grenadesAmount;

    [SerializeField] float stunCD;
    bool SonCD;
    bool isStunning;
    public Image stunCool;
    // ------------------------------


    public bool isGrounded;

    void Start()
    {
        walkingSoundEff = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        stunCool.gameObject.SetActive(false);
        StartCoroutine(PausePlayerAtBeginning());
    }
    void Update()
    {
        // player movement system:
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") && isGrounded)
        {
            walkingSoundEff.Play();

        }
        else if (!isGrounded || !Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
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
        Stun();

        if (Input.GetKeyDown(KeyCode.H) & heals > 0)
        {
            isHealing = true;
            heals--;
        }


        if (Health >= 300)
        {
            Health = 300;
        }

        // player abilities UI
        grenadesAmount.text = grenades.ToString();
        healsAmount.text = heals.ToString();
        if(playerLives == 0)
        {
            GameOver();
            Debug.Log("skill issue");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        livesCount.text = playerLives.ToString();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G) & grenades > 0)
        {
            ThrowGrenade();
            grenades--;
        }
        if (!SonCD)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isStunning = true;
                stunCool.fillAmount = 1;
            }
        }
        Vector3 playerPos = transform.position;
        if (Health <= 0 || playerPos.y < -20)
        {
            Health = 300;
            playerLives -= 1;
            switch (ChallengeIndex)
            {
                case 0:
                    transform.position = new Vector3(237, 5, 173); break;
                case 1:
                    transform.position = new Vector3(192, 8, 174); break;
                case 3:
                    transform.position = new Vector3(564, 16, 663); break;
            }
        }
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    speed = speed * 1.5f;
        //}
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    speed = speed / 1.5f;
        //}
    }
    void StemShot() // Ability 1
    {
        if (isHealing)
        {
            Health += 0.6f;
            healingTime += Time.deltaTime;
            healVFX.gameObject.SetActive(true);
            if (healingTime >= 3)
            {
                isHealing = false;
                healingTime = 0;
                healVFX.gameObject.SetActive(false);
            }
        }
    }

    void ThrowGrenade() // Ability 2
    {
        Rigidbody rb = Instantiate(Grenade, camera.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(camera.transform.forward * 15, ForceMode.Impulse);
        Debug.Log("NBAyoungboy");
    }


    void Stun() // Ability 3
    {

        if (isStunning)
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
            isStunning = false;
            SonCD = true;
        }
        if (SonCD)
        {
            stunCD += Time.deltaTime;
            stunCool.gameObject.SetActive(true);
            stunCool.fillAmount -= stunCD / 4000;
        };
        if (stunCD >= 8)
        {
            SonCD = false;
            stunCD = 0;
            stunCool.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slow"))
        {
            speed = speed / 2.3f;
        }
        
        if (other.gameObject.CompareTag("BossTerrain"))
        { 
            transform.position = new Vector3(530, 132, 1435);
            Health -= 30;
        }
        if (other.gameObject.CompareTag("BossTP") && ChallengeIndex ==4)
        {
            transform.position = new Vector3(530, 140, 1435);
            speed = 55;
        }
        if (other.gameObject.CompareTag("SpitterSpit"))
        {
            Health -= 15;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Slow"))
        {
            speed = speed * 2.3f;
        }
    }
    void GameOver() 
    {
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator PausePlayerAtBeginning()
    {
        float tempSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(15f);
        speed = tempSpeed;
        
    }
}
