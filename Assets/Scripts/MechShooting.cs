using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MechShooting : MonoBehaviour
{
    public GameObject mg, rl_1, rl_2, blaster, head;
    public MechMovement mm;
    private Vector3 shootTarget;
    private Dictionary<GameObject, Vector3> gun_to_tar;
    private List<GameObject> guns;
    private int mode;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        mode = Random.Range(1, 4);
        timer = -1;
        gun_to_tar = new Dictionary<GameObject, Vector3>
        {
            { mg, new Vector3(0, 0, 0) },
            { blaster, new Vector3(0, 0, 0) },
            { rl_1, new Vector3(0, 0, 0) },
            { rl_2, new Vector3(0, 0, 0) }
        };
        guns = new List<GameObject>(gun_to_tar.Keys);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject gun in guns)
        {
            gun_to_tar[gun] = mm.player_v + (mm.player.GetComponent<Rigidbody>().velocity * (mm.player_v.magnitude / gun.GetComponent<Gun>().bulletSpeed));
            
        }
        if (mm.withinRange)
        {
            timer += Time.deltaTime;
            if (mode == 1)
            {
                if (timer > 0)
                {
                    print("shooting left");
                    head.transform.LookAt(transform.position + gun_to_tar[rl_1]);
                    rl_1.GetComponent<Gun>().shoot();
                }
                if (timer > 0.5)
                {
                    head.transform.LookAt(transform.position + gun_to_tar[rl_2]);
                    rl_2.GetComponent<Gun>().shoot();
                }
                if (timer > 5)
                {
                    timer = 0;
                    mode = 2;
                }
            }
            if (mode == 2)
            {
                head.transform.LookAt(transform.position + gun_to_tar[mg]);
                mg.GetComponent<Gun>().shoot();
                if (timer > 5)
                {
                    timer = 0;
                    mode = 3;
                }
            }
            if (mode == 3)
            {
                head.transform.LookAt(transform.position + gun_to_tar[blaster]);
                blaster.GetComponent<Gun>().shoot();
                if (timer > 5)
                {
                    timer = 0;
                    mode = 1;
                }
            }

        }
        //print(timer);
        
    }
}
