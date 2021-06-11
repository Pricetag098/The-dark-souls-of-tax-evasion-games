using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent m_navmesh;
    public GameObject safe;
    public GameObject player;
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
        if (player_v.magnitude < 10)
        {
            m_navmesh.SetDestination(player.transform.position);
        }
        else
        {
            m_navmesh.SetDestination(safe.transform.position);
        }
    }
}
