using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechShooting : MonoBehaviour
{
    public GameObject mg, rl_1, rl_2, blaster, head;
    public MechMovement mm;
    private Vector3 shootTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTarget = mm.player_v + (mm.player.GetComponent<Rigidbody>().velocity * (mm.player_v.magnitude / blaster.GetComponent<Gun>().bulletSpeed));
        head.transform.LookAt(transform.position + shootTarget);
        if (mm.withinRange)
        {
            blaster.GetComponent<Gun>().shoot();
        }
        
    }
}
