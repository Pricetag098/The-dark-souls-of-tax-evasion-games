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
    private bool l_fired;
    private bool r_fired;
    public LayerMask whatIsEnemy;
    public Health mh;

    // Start is called before the first frame update
    void Start()
    {
        mode = 1;
        timer = 0;
        l_fired = false;
        r_fired = false;
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
                head.transform.LookAt(transform.position + gun_to_tar[mg]);
                RaycastHit hit;
                if (Physics.Raycast(mg.GetComponent<Gun>().head.transform.position, shootTarget, out hit, Mathf.Infinity, whatIsEnemy))
                {

                }
                else
                {
                    mg.GetComponent<Gun>().shoot();
                }
                
                if (timer > 5)
                {
                    timer = 0;
                    mode = 2;
                    mg.GetComponent<Gun>().reload();
                }
                if (mh.health / mh.maxHealth < 0.5)
                {
                    head.transform.LookAt(transform.position + gun_to_tar[blaster]);
                    RaycastHit hit2;
                    if (Physics.Raycast(head.transform.position, shootTarget, out hit2, Mathf.Infinity, whatIsEnemy))
                    {

                    }
                    else
                    {
                        blaster.GetComponent<Gun>().shoot();
                    }
                }

            }
            if (mode == 2)
            {
                if (timer > 1)
                {
                    if (l_fired == false)
                    {
                        head.transform.LookAt(transform.position + gun_to_tar[rl_1]);
                        RaycastHit hit;
                        if (Physics.Raycast(head.transform.position, shootTarget, out hit, Mathf.Infinity, whatIsEnemy))
                        {

                        }
                        else
                        {
                            rl_1.GetComponent<Gun>().shoot();
                            l_fired = true;
                        }
                        
                        
                    }
                    
                }
                if (timer > 2)
                {
                    if (r_fired == false)
                    {
                        print("shooting left");
                        head.transform.LookAt(transform.position + gun_to_tar[rl_2]);
                        RaycastHit hit;
                        if (Physics.Raycast(head.transform.position, shootTarget, out hit, Mathf.Infinity, whatIsEnemy))
                        {

                        }
                        else
                        {
                            rl_2.GetComponent<Gun>().shoot();
                            r_fired = true;
                        }
                        
                        
                    }
                }
                if (timer > 3)
                {
                    timer = 0;
                    mode = 1; 
                    rl_1.GetComponent<Gun>().reload();
                    rl_2.GetComponent<Gun>().reload();
                    l_fired = false;
                    r_fired = false;
                }
            }

            if (mode == 3)
            {
                
                
                if (timer > 5)
                {
                    timer = 0;
                    mode = 1;
                }
            }

        }
        //print(timer);

    }

    IEnumerator shooting(GameObject rocket_launcher)
    {
        yield return new WaitForSeconds(1);
        rocket_launcher.GetComponent<Gun>().shoot();

    }
}