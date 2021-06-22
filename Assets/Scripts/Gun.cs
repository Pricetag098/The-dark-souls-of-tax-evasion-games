using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    

    Vector3 defPos;
    float reloadProgression;

	[Header("GunVariables")]
    public bool isReloading;
    public int bulletCount;
    public float damage, bulletSpeed, fireRate, spread;
	public int ammo, maxAmmo;
	public bool isAuto = true;
	public float rEndPos;
	public float reloadTime;

	//public float distanceFromFace;

	float shootTime = 0f;

	[Header("Setup")]
    public Transform head,tip;
    public GameObject bulletPrefab;

    [Header("Sound")]
    public AudioClip shootSound;
    public float pitchRange;
    float defPitch;

    AudioSource audioSource;


	float defFov;
	public enum AdsMode { none, iron, holo, scope};
	[Header("ADS Variables")]
	public AdsMode adsMode;
	public Vector3 AdsPos;
	public float adsRate, scopeMulti,zoomRate;
	public GameObject scopeGo;


    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
        defPos = transform.localPosition;
		defFov = cam.fieldOfView;
        defPitch = audioSource.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAuto)
        {
            if (Input.GetMouseButton(0))
            {
                shoot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                    shoot();
            }
        }
        shootTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }

        if (isReloading)
        {
            reloadProgression += Time.deltaTime;

            transform.localPosition = defPos + new Vector3(0, -reloadPos(), 0);

            if(reloadProgression > reloadTime)
            {
                ammo = maxAmmo;
                isReloading = false;
                shootTime = fireRate; 
                transform.localPosition = defPos;
            }
        }
		DoAds();
    }
    
     public void shoot()
    {
       
        if (shootTime >= fireRate)
        {

            if (ammo <= 0)
            {
                if (isReloading)
                {
                    return;
                }
                reload();
                
            }

            for (int i = 0; i < bulletCount; i++)
            {
                Vector3 dir = head.transform.forward;
                RaycastHit hit;
                if (Physics.Raycast(head.position, head.transform.forward, out hit, Mathf.Infinity))
                {
                    dir = (hit.point - tip.transform.position).normalized;
                }




                Vector3 rand = new Vector3(
                    -Random.value + Random.value,
                    -Random.value + Random.value,
                    -Random.value + Random.value
                    ).normalized;

                GameObject bullet = Instantiate(bulletPrefab, tip.position, Quaternion.Euler(transform.forward));
                bullet.transform.position = tip.position;
                bullet.GetComponent<Bullet>().GO((dir + (rand * spread)) * bulletSpeed, damage);
                Destroy(bullet, 5);
            }
            ammo--;
            shootTime = 0;

            if (shootSound)
            {
                //audioSource.clip = shootSound;
                audioSource.pitch = defPitch + Random.Range(-pitchRange,pitchRange);
                audioSource.PlayOneShot(shootSound);
            }

        }
    }
    void reload()
    {
        if (!isReloading && ammo != maxAmmo)
        {
            reloadProgression = 0;
            isReloading = true;
        }
    }
    private void OnEnable()
    {
        //print(gameObject.name);
    }
	private void OnDisable()
	{
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, defPos, adsRate);
        if (cam)
        {
            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, defFov, zoomRate);
        }
		

		if (Vector3.Distance(transform.localPosition, AdsPos) > .01f)
		{
			if (GetComponent<MeshRenderer>())
			{
				GetComponent<MeshRenderer>().enabled = true;
			}
			else if (GetComponentsInChildren<MeshRenderer>().Length > 0)
			{
				foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
				{
					meshRenderer.enabled = true;
				}
			}
			if (scopeGo)
			{
				scopeGo.SetActive(false);
			}

		}
	}
	float reloadPos()
    {
        ///print(Mathf.Clamp(rEndPos * Mathf.Sin(reloadProgression * ((2 * Mathf.PI) / reloadTime)), 0, Mathf.Infinity));
        return  Mathf.Clamp(rEndPos * Mathf.Sin(reloadProgression * (( Mathf.PI) /reloadTime)),0,999999);
    }


	void DoAds()
	{
		bool doAds = Input.GetMouseButton(1);
		if (!doAds || isReloading)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, defPos, adsRate);
			cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, defFov, zoomRate);

			if (Vector3.Distance(transform.localPosition, AdsPos) > .01f)
			{
				if (GetComponent<MeshRenderer>())
				{
					GetComponent<MeshRenderer>().enabled = true;
				}
				else if (GetComponentsInChildren<MeshRenderer>().Length > 0)
				{
					foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
					{
						meshRenderer.enabled = true;
					}
				}
				if (scopeGo)
				{
					scopeGo.SetActive(false);
				}

			}
		}
		if (isReloading)
		{
			return;
		}
		if (doAds)
		{
			switch (adsMode)
			{
				case AdsMode.scope:
					{

						transform.localPosition = Vector3.MoveTowards(transform.localPosition, AdsPos, adsRate);
						cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, defFov / scopeMulti, zoomRate);
						if (Vector3.Distance(transform.localPosition, AdsPos) < .01f)
						{
							if (GetComponent<MeshRenderer>())
							{
								GetComponent<MeshRenderer>().enabled = false;
							}
							else if (GetComponentsInChildren<MeshRenderer>().Length > 0)
							{
								foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
								{
									meshRenderer.enabled = false;
								}
							}

							scopeGo.SetActive(true);
						}
					}

					break;



				case AdsMode.iron:
					{
						transform.localPosition = Vector3.MoveTowards(transform.localPosition, AdsPos, adsRate);
						cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, defFov / scopeMulti, zoomRate);

						break;
					}
			}
		}
		

	}
}
