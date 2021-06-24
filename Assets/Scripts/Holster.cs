using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour
{
    public int ammo, maxAmmo;


    int selectedWeapon = 0;


    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(selectedWeapon >= transform.childCount-1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
            SelectWeapon();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount -1;
            }
            else
            {
                selectedWeapon--;
            }
            SelectWeapon();
        }
        Gun gun = transform.GetChild(selectedWeapon).gameObject.GetComponent<Gun>();
        if (gun)
        {
            ammo = gun.ammo;
            maxAmmo = gun.maxAmmo;
        }
        else
        {
            ammo = 0;
            maxAmmo = 0;
        }
    }

    void SelectWeapon()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(i == selectedWeapon)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
