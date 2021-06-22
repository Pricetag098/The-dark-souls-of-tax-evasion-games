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

        // holster.transform.right = -(player.transform.position - gameObject.transform.position).normalized;
        if (em.withinRange == true) { 
            m_gun.GetComponent<Gun>().shoot();
        }
    }
}
