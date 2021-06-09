using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float rEndPos;
    public float reloadTime;

    Vector3 defPos;
    float reloadProgression;

    public bool isReloading;

    public int bulletCount;
    public float damage, bulletSpeed, fireRate, spread;

    public float distanceFromFace;

    float shootTime = 0f;
    public Transform head,tip;

    public GameObject bulletPrefab;

    public int ammo, maxAmmo;

    public bool isAuto = true;

    // Start is called before the first frame update
    void Start()
    {
        defPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAuto)
        {
            if (Input.GetMouseButton(0))
            {
                if(shootTime >= fireRate)
                {
                    shoot();
                    shootTime = 0;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (shootTime >= fireRate)
                {
                    shoot();
                    shootTime = 0;
                }
            }
        }
        shootTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R) && !isReloading && ammo != maxAmmo)
        {
            reloadProgression = 0;
            isReloading = true;
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
        
    }
    
    void shoot()
    {
        if(ammo <= 0 || isReloading)
        {
            return;
        }

        for(int i = 0; i < bulletCount; i++)
        {
            Vector3 dir = head.transform.forward;
            RaycastHit hit;
            if(Physics.Raycast(head.position, head.transform.forward,out hit, Mathf.Infinity))
            {
                dir = (hit.point-tip.transform.position).normalized; 
            }
            
            


            Vector3 rand = new Vector3(
                -Random.value + Random.value, 
                -Random.value + Random.value,
                -Random.value + Random.value
                ).normalized;
            
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = tip.position;
            bullet.GetComponent<Bullet>().GO((dir + (rand * spread)) * bulletSpeed, damage);
            Destroy(bullet, 5);
        }
        ammo--;
    }
    
    float reloadPos()
    {
        ///print(Mathf.Clamp(rEndPos * Mathf.Sin(reloadProgression * ((2 * Mathf.PI) / reloadTime)), 0, Mathf.Infinity));
        return  Mathf.Clamp(rEndPos * Mathf.Sin(reloadProgression * (( Mathf.PI) /reloadTime)),0,999999);
    }
}
