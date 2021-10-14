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
    bool isScoped = false;
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

    public new_weapon_recoil_script recoil;
   
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
        if (isSniper == true && Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            if (isScoped)
                StartCoroutine(OnScoped());
            else
                UnScoped();
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

        recoil.Firerecoil();


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
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        crosshair.SetActive(false);

        normalFOV = fpsCam.fieldOfView;
        fpsCam.fieldOfView = scopedFOV;

    }

    void UnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        crosshair.SetActive(true);

        fpsCam.fieldOfView = normalFOV;
    }
}
