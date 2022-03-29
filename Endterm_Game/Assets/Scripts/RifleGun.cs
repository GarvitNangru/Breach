using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RifleGun : MonoBehaviour
{
    public float damage = 50f;
    public float range = 100f;
    public float firerate = 20f;
    private float nextTimeToFire = 0f;

    public int maxAmmo = 90;
    public int maxReloadedAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 2f;

    int ammoTobeAdded=0;

    private bool isReloading=false;

    private Animator animator;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    [SerializeField] AudioSource shootAudio;
    public GameObject impactEffect;

    public TMP_Text reloadText;
    public LayerMask layersToCollide;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentAmmo = maxReloadedAmmo;
        // recoilscript = transform.Find("CameraRot/CameraRecoil").GetComponent<Recoil>();
    }
    void Update()
    {
      
        if (isReloading)
            return;

       

        if (currentAmmo <= 0 && maxAmmo > 0)
        {
            StartCoroutine(reload());
         //   isReloading = true;

        }
        else if(Input.GetKeyDown(KeyCode.R) && maxAmmo>0 && currentAmmo!=maxReloadedAmmo && !isReloading)
        {
            StartCoroutine(reload());
       //     isReloading = true;

        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / firerate;
            shoot();
        }
        reloadText.text = currentAmmo + "/" + maxAmmo;
    }

    IEnumerator reload()
    {
        isReloading = true;
        animator.SetTrigger("Reloading");
        yield return new WaitForSeconds(2);

        if (currentAmmo <= 0)
        {
            maxAmmo -= maxReloadedAmmo;
            ammoTobeAdded = maxReloadedAmmo;
        }
        else
        {
            ammoTobeAdded = maxReloadedAmmo - currentAmmo;

            if (ammoTobeAdded >= maxAmmo)
                ammoTobeAdded = maxAmmo;

            maxAmmo -= ammoTobeAdded;
            if (maxAmmo < 0)
                maxAmmo = 0;
        }
        currentAmmo += ammoTobeAdded;
        isReloading = false;
    }

    void shoot()
    {
     
        currentAmmo--;
        muzzleFlash.Play();
        shootAudio.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range,layersToCollide))
        {

            if(hit.transform.gameObject.CompareTag("Drone"))
            {
                hit.transform.gameObject.GetComponent<Drone_Health>().TakeDamage(20f);
            }


            Vector3 direction = hit.collider.gameObject.transform.position - transform.position;
            //var rb = hit.collider.GetComponent<Rigidbody>();
            //if (rb != null)
            //{

            //    Debug.Log("hit");
            //    rb.AddForceAtPosition(direction * 10, hit.point, ForceMode.Impulse);
            //}

            var hitBox = hit.collider.GetComponent<HitBox>();
            if (hitBox != null)
            {
                hitBox.OnRayCastHit(this, direction);
            }


         //   Debug.Log(hit.transform.name);
        }
        GameObject go = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(go, 2.0f);
    }
}
