using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject holster;
    private GameObject m_gun;
    public Transform m_head;
    public GameObject player;
    public EnemyMovement em;
    public LayerMask whatIsEnemy;
    private Vector3 shootTarget;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gun = guns[Random.Range(0, guns.Length)];
        m_gun = Instantiate(gun, holster.transform.position, holster.transform.rotation);
        m_gun.transform.parent = holster.transform;
        m_gun.transform.localScale = new Vector3(2, 2, 2);
        m_gun.GetComponent<Gun>().head = m_head;
    }

    // Update is called once per frame
    void Update()
    {
        shootTarget = em.player_v + (em.player.GetComponent<Rigidbody>().velocity * (em.player_v.magnitude / m_gun.GetComponent<Gun>().bulletSpeed));
        m_gun.GetComponent<Gun>().head.LookAt(transform.position + shootTarget);

        if (em.withinRange == true) {
            RaycastHit hit;
            if (Physics.Raycast(m_gun.GetComponent<Gun>().head.transform.position, shootTarget, out hit, Mathf.Infinity, whatIsEnemy))
            {
                
            }
            else
            {
                m_gun.GetComponent<Gun>().shoot();
            }
                
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(gameObject.transform.position, shootTarget);
    }
}

