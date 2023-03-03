using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(AudioSource))]
public class GunController : MonoBehaviour {



    [SerializeField]
    private Gun currentGun;

    private float currentFireRate;

    [HideInInspector]
    public bool isFineSightMode = false;

    // 본래 포지션 값.
    private Vector3 originPos;

    private AudioSource audioSource;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public GameObject crosshair;
    private RaycastHit hitInfo;

    [SerializeField]
    private Camera theCam;

    [SerializeField]
    private GameObject hit_effect_prefab; 

    [SerializeField]
    private PlayerController player;

    void Start()
    {
        originPos = Vector3.zero;
        audioSource = GetComponent<AudioSource>();
    }

	void Update () 
    {
        GunFireRateCalc();
        TryFire();
        TryFindSight();
	}

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
    }

    private void TryFire()
    {
        if (Input.GetButtonDown("Fire1") && currentFireRate <= 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Shoot();
    }

    private void Shoot()
    {
        currentFireRate = currentGun.fireRate;
        PlaySound(currentGun.fire_Sound);
        currentGun.muzzleFlash.Play();
        Hit();

    }
    private void Hit()
    {
        if (Physics.Raycast(theCam.transform.position, theCam.transform.forward, out hitInfo, currentGun.range));
        {
            GameObject clone = Instantiate(hit_effect_prefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            //Debug.Log(hitInfo.transform.name);
            Destroy(clone, 2f);

            if (hitInfo.transform.tag == "Target")
            {
             hitInfo.transform.GetComponent<Target>().TargetOnHit();
            }
        }
    }

    private void TryFindSight()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            FineSight();
        }
    }
    

    private void FineSight()
    {
        isFineSightMode = !isFineSightMode;
        currentGun.anim.SetBool("FineSightMode", isFineSightMode);

        scopeOverlay.SetActive(isFineSightMode);

        if (isFineSightMode)
        {
            StopAllCoroutines();
            StartCoroutine(FineSightActivateCoroutine());

            weaponCamera.SetActive(false);
            crosshair.SetActive(false);
            theCam.fieldOfView = 15;
            player.lookSensitivity = player.lookSensitivity * 0.5f;
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(FineSightDeactivateCoroutine());

            weaponCamera.SetActive(true);
            crosshair.SetActive(true);
            theCam.fieldOfView = 60;
            player.lookSensitivity = player.lookSensitivity * 2f;
        }
    }

    IEnumerator FineSightActivateCoroutine()
    {
        while(currentGun.transform.localPosition != currentGun.fineSightOriginPos)
        {
            currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, currentGun.fineSightOriginPos, 0.2f);
            yield return null;
        }
    }
    IEnumerator FineSightDeactivateCoroutine()
    {
        while(currentGun.transform.localPosition != originPos)
        {
            currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, originPos, 0.2f);
            yield return null;
        }
    }

    private void PlaySound(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play();

    }
}
