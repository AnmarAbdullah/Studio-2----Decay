using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 100f;
    public float fireRate = 15f;
    public bool autoFire;
    public float scopedFOV = 15f;

    public int maxAmmo = 10;
    int currentAmmoAmount = -1;
    public float reloadTime = 1f;
    bool isReloading = false;
    public bool isScoped = false;
    public bool isSniper;
    float normalFOV;


    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public GameObject crosshair;

    public AudioSource fireSound;
    public AudioSource reloadSound;

    float nextTimeToFire = 0f;

    public Animator animator;

    

    private void Start()
    {
        if (currentAmmoAmount == -1)
            currentAmmoAmount = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    void Update()
    {
        if (isSniper == true && Input.GetButtonDown("Fire2"))
        {
            if (!isScoped)
                StartCoroutine(OnScoped());
            else
                UnScoped();
        }

        if (isReloading)
            return;

        if ((Input.GetKeyDown(KeyCode.R) && currentAmmoAmount < maxAmmo) || currentAmmoAmount <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (autoFire == true && Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (autoFire == false && Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
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

        currentAmmoAmount = maxAmmo;
        isReloading = false;
    }
    void Shoot()
    {
        currentAmmoAmount--;

        muzzleFlash.Play();
        fireSound.Play();     

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

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactGO, 2f);
        }

    }

    IEnumerator OnScoped()
    {
        isScoped = true;
        animator.SetBool("Scoped", isScoped);
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
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
        weaponCamera.SetActive(true);
        crosshair.SetActive(true);

        fpsCam.fieldOfView = normalFOV;
    }
}
