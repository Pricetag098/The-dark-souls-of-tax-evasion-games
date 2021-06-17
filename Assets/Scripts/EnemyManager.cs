using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject holster;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gun = guns[Random.Range(0, guns.Length)];
        var myGun = Instantiate(gun, transform.position, Quaternion.identity);
        myGun.transform.parent = holster.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
