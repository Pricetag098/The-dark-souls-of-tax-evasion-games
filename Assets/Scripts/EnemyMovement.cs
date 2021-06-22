using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent m_navmesh;
    public GameObject safe;
    public GameObject player;
    public bool withinRange;
    // Start is called before the first frame update
    void Start()
    {
        m_navmesh.SetDestination(safe.transform.position);
        m_navmesh.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_v = player.transform.position - transform.position;
        if (player_v.magnitude < 30 && Vector3.Angle(transform.forward, player_v) < 85 && Vector3.Angle(transform.forward, player_v) > -85)
        {
            withinRange = true;
            m_navmesh.isStopped = false;
            m_navmesh.SetDestination(player.transform.position);
            if (player_v.magnitude < 5)
            {
                transform.forward = player_v;
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
        // print(player_v.magnitude);
    }
}
