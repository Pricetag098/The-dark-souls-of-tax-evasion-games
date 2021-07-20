using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MechMovement : MonoBehaviour
{
    public NavMeshAgent m_navmesh;
    public GameObject safe;
    public GameObject player;
    public bool withinRange;
    public Vector3 player_v;
    // Start is called before the first frame update
    void Start()
    {
        m_navmesh.SetDestination(safe.transform.position);
        m_navmesh.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        player_v = player.transform.position - transform.position;
        if (player_v.magnitude < 30 && Vector3.Angle(transform.forward, player_v) < 85 && Vector3.Angle(transform.forward, player_v) > -85)
        {
            transform.forward = new Vector3(player_v.x, transform.forward.y, player_v.z);
            withinRange = true;
            m_navmesh.isStopped = false;
            m_navmesh.SetDestination(player.transform.position);
            if (player_v.magnitude < 5)
            {
                
                m_navmesh.isStopped = true;
            }
        }
        else
        {
            withinRange = false;
            m_navmesh.isStopped = false;
            m_navmesh.SetDestination(safe.transform.position);
            if (Vector3.Distance(transform.position, safe.transform.position) < 2)
            {
                m_navmesh.isStopped = true;
            }
        }
        print("length: " +player_v.magnitude);
    }
}
