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
    public Vector3 player_v;
    public Material[] skins;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        m_navmesh.SetDestination(safe.transform.position);
        m_navmesh.isStopped = false;
        Material m_skin = skins[UnityEngine.Random.Range(0, skins.Length)];
        SkinnedMeshRenderer renderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

        renderer.material = m_skin;
    }

    // Update is called once per frame
    void Update()
    {
        player_v = player.transform.position - transform.position;
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
            if (Vector3.Distance(transform.position, safe.transform.position) < 10)
            {
                gm.lives -= Mathf.Round(500000*Time.deltaTime);
            }
        }
        // print(player_v.magnitude);
    }
}
