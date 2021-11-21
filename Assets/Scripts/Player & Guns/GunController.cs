using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class GunController : MonoBehaviour
{
    [Header("Gun Settings")]
    public float fireRate = 0.1f;
    public int clipSize = 30;
   public int ammoInClip;
    public int reservedAmmoCapacity = 270;
    public float impactForce = 100f;
    public float range = 100f;
    public float damage = 10f;
    public float reloadTime = 1f;
    public float scopedFOV = 15f;
    public bool isSniper = false;
    public bool isLauncher = false;
    public float launcherForce;

    bool canShoot;
    int ammoInReserve;
    bool isReloading = false;
    bool isScoped = false;
    float normalFOV;
    Transform myTransform;

    public GameObject scopeOverlay;
    public GameObject crosshair;
    public GameObject rocketPrefab;
    //public GameObject weaponCamera;
    public GameObject enemyImpactEffect;
    public Animator animator;
    public AudioSource fireSound;
    
    public VisualEffect muzzleFlash;

    public Vector3 normalLocalPosition;
    public Vector3 aimingLocalPosition;
    public float normalFOVPosition;
    public float desiredFOVPosition;

    public float aimSmoothing = 10;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 1;
    public Vector2 currentRotation;
    public float weaponSwayAmount = 5;

    public Camera fpsCam;

    [Header("Recoil")]
    public Vector2[] recoilPattern;

    private void Start()
    {
        ammoInClip = clipSize;
        ammoInReserve = reservedAmmoCapacity;
        canShoot = true;
        myTransform = transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
        
    }
    private void Update()
    {
        Aim();
        Rotation();

        if (isReloading)
            return;

        reservedAmmoCapacity = ammoInReserve;
        if (Input.GetMouseButton(0) && canShoot && ammoInClip > 0)
        {
            canShoot = false;
            ammoInClip--;
            StartCoroutine(Shoot());
        }
        else if (Input.GetKeyDown(KeyCode.R) && ammoInClip < clipSize && ammoInReserve > 0 || ammoInClip <= 0)
        {
            StartCoroutine(Reload());
            
            int amountNeeded = clipSize - ammoInClip;
            if (amountNeeded >= ammoInReserve)
            {
                ammoInClip += ammoInReserve;
                ammoInReserve = 0 ;

            }
            else
            {
                ammoInClip = clipSize;
                ammoInReserve -= amountNeeded;
            }
        }
        
    }

    

    void Rotation()
    {
        Vector2 mouseAxis = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseAxis *= mouseSensitivity;
        currentRotation += mouseAxis;

        currentRotation.y = Mathf.Clamp(currentRotation.y, -90, 90);

        transform.localPosition += (Vector3)mouseAxis * weaponSwayAmount / 1000;

        transform.root.localRotation = Quaternion.AngleAxis(currentRotation.x, Vector3.up);
        transform.parent.parent.localRotation = Quaternion.AngleAxis(-currentRotation.y, Vector3.right);
    }
    void Aim()
    {

        if (isSniper == true && Input.GetButtonDown("Fire2"))
        {

            if (!isScoped)
                StartCoroutine(OnScoped());
            else
                UnScoped();

        }
        
        Vector3 target = normalLocalPosition;
        float fovTarget = normalFOVPosition;
        
        

        if (isSniper == false && Input.GetMouseButton(1))
        {
            target = aimingLocalPosition;
            fovTarget = desiredFOVPosition;
            //fpsCam.fieldOfView = scopedFOV;
            crosshair.SetActive(false);

        }

        if (isSniper == false && Input.GetMouseButtonUp(1))
        {
            
            crosshair.SetActive(true);
            
        }


        Vector3 desiredPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmoothing);

        float povDesiredPosition = Mathf.Lerp(Camera.main.fieldOfView, fovTarget, Time.deltaTime * aimSmoothing);

        transform.localPosition = desiredPosition;

        if (isSniper == false)
        {
            Camera.main.fieldOfView = povDesiredPosition;         
        }
        

        

    }


    void Recoil()
    {
        if (isSniper == false)
        {
            transform.localPosition -= Vector3.forward * 0.1f;

            int currentStep = clipSize + 1 - ammoInClip;
            currentStep = Mathf.Clamp(currentStep, 0, recoilPattern.Length - 1);

            currentRotation += recoilPattern[currentStep];
        }

    }
    IEnumerator Shoot()
    {
        if (isLauncher == false && isSniper == false)
        {
            Recoil();
            MuzzleFlash();
            RaycastToTarget();
            fireSound.Play();
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }
        if (isLauncher)
        {
            ShootRocket();
            canShoot = true;
        }
        
    }

    void MuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void RaycastToTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(enemyImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactGO, 2f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        isReloading = false;

        
    }

    IEnumerator OnScoped()
    {

        isScoped = true;
        animator.SetBool("Scoped", isScoped);
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        //weaponCamera.SetActive(false);
        crosshair.SetActive(false);

        normalFOV = fpsCam.fieldOfView;
        fpsCam.fieldOfView = scopedFOV;
    }

    public void UnScoped()
    {

        if (!isScoped)
            return;

        isScoped = false;
        animator.SetBool("Scoped", isScoped);
        scopeOverlay.SetActive(false);
        //weaponCamera.SetActive(true);
        crosshair.SetActive(true);

        fpsCam.fieldOfView = normalFOV;
    }

    void ShootRocket()
    {
        GameObject rocket = (GameObject)Instantiate(rocketPrefab, myTransform.transform.TransformPoint(0, 0, 0), myTransform.rotation);
        rocket.GetComponent<Rigidbody>().AddForce(myTransform.forward * launcherForce, ForceMode.Impulse);
        Destroy(rocket, 2);
        //Instantiate(rocketPrefab, myTransform.transform.TransformPoint(0,0,2f), myTransform.rotation);
    }
}
