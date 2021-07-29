using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject agent;
    public GameObject mech;
    public GameObject safe;
    public GameObject player_b;
    public int wave;
    public int lives;
    public int state;
    private bool spawned;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        lives = 1000000000;
        wave = 1;
        state = 2;
        spawned = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (state == 2)
        {
            if (wave == 1)
            {
                if (timer > 2 && spawned == false)
                {
                    SpawnAgent(2);
                    timer = 0;
                    spawned = true;
                }
            }
        }
    }

    void SpawnAgent(int num) {
        for (int i = 0; i<num; i++) {
            GameObject a1 = Instantiate(agent);
            a1.transform.position = SpawnPoint.position;
            a1.GetComponent<EnemyMovement>().safe = safe;
            a1.GetComponent<EnemyMovement>().player = player_b;
        }
    }

    void SpawnMech(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(mech, SpawnPoint);
        }
    }

}
