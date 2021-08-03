using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject agent;
    public GameObject mech, joe;
    public GameObject safe;
    public GameObject player_b;
    public int wave;
    public float lives;
    public int state;
    public bool spawned;
    private float timer;
    public GameManager gm;


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
        if (state == 1)
        {

        }
        if (state == 2)
        {
            if (wave == 1)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 5);
                    Invoke("SpawnAgent", 10);
                    Invoke("SpawnAgent", 15);
                    Invoke("SpawnAgent", 20);
                    spawned = true;
                }
                
                if (timer > 20)
                {
                    enemyCheck();
                }
            }
            if (wave == 2)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 12);
                    Invoke("SpawnAgent", 16);
                    Invoke("SpawnAgent", 20);
                    Invoke("SpawnAgent", 24);
                    spawned = true;
                }

                if (timer > 24)
                {
                    enemyCheck();
                }
            }
            if (wave == 3)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8); 
                    Invoke("SpawnAgent", 12);
                    Invoke("SpawnAgent", 16);
                    Invoke("SpawnAgent", 16);
                    Invoke("SpawnAgent", 22);
                    Invoke("SpawnAgent", 22);
                    Invoke("SpawnAgent", 22);
                    spawned = true;
                }

                if (timer > 22)
                {
                    enemyCheck();
                }
            }
            if (wave == 4)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 12);
                    Invoke("SpawnAgent", 12);
                    Invoke("SpawnAgent", 16);
                    Invoke("SpawnAgent", 16);
                    Invoke("SpawnAgent", 20);
                    Invoke("SpawnAgent", 20);
                    spawned = true;
                }

                if (timer > 20)
                {
                    enemyCheck();
                }
            }
            if (wave == 5)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnMech", 8);
                    spawned = true;
                }

                if (timer > 8)
                {
                    enemyCheck();
                }
            }
            if (wave == 6)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    spawned = true;
                }

                if (timer > 8)
                {
                    enemyCheck();
                }
            }
            if (wave == 7)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnMech", 8);
                    spawned = true;
                }

                if (timer > 8)
                {
                    enemyCheck();
                }
            }
            if (wave == 8)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnMech", 8);
                    spawned = true;
                }

                if (timer > 8)
                {
                    enemyCheck();
                }
            }
            if (wave == 9)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 2);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnAgent", 6);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnMech", 10);
                    spawned = true;
                }

                if (timer > 10)
                {
                    enemyCheck();
                }
            }
            if (wave == 10)
            {
                if (spawned == false)
                {
                    Invoke("SpawnMech", 2);
                    Invoke("SpawnMech", 2);
                    spawned = true;
                }

                if (timer > 2)
                {
                    enemyCheck();
                }
            }
            if (wave == 11)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnMech", 8);
                    spawned = true;
                }

                if (timer > 8)
                {
                    enemyCheck();
                }
            }
            if (wave == 12)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnMech", 12);
                    Invoke("SpawnMech", 12);
                    spawned = true;
                }

                if (timer > 12)
                {
                    enemyCheck();
                }
            }
            if (wave == 13)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnMech", 12);
                    Invoke("SpawnMech", 12);
                    spawned = true;
                }

                if (timer > 12)
                {
                    enemyCheck();
                }
            }
            if (wave == 14)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnMech", 12);
                    Invoke("SpawnMech", 12);
                    spawned = true;
                }

                if (timer > 12)
                {
                    enemyCheck();
                }
            }
            if (wave == 15)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnMech", 8);
                    Invoke("SpawnMech", 12);
                    Invoke("SpawnMech", 16);
                    spawned = true;
                }

                if (timer > 16)
                {
                    enemyCheck();
                }
            }
            if (wave == 16)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnMech", 8);
                    Invoke("SpawnMech", 12);
                    Invoke("SpawnMech", 16);
                    spawned = true;
                }

                if (timer > 16)
                {
                    enemyCheck();
                }
            }
            if (wave == 17)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnMech", 8);
                    Invoke("SpawnMech", 12);
                    Invoke("SpawnMech", 16);
                    spawned = true;
                }

                if (timer > 16)
                {
                    enemyCheck();
                }
            }
            if (wave == 18)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnMech", 8);
                    Invoke("SpawnMech", 12);
                    Invoke("SpawnMech", 16);
                    spawned = true;
                }

                if (timer > 16)
                {
                    enemyCheck();
                }
            }
            if (wave == 19)
            {
                if (spawned == false)
                {
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 4);
                    Invoke("SpawnAgent", 8);
                    Invoke("SpawnAgent", 8);

                    Invoke("SpawnAgent", 10);
                    Invoke("SpawnAgent", 10);
                    Invoke("SpawnAgent", 10);
                    Invoke("SpawnAgent", 10);

                    Invoke("SpawnAgent", 12);
                    Invoke("SpawnAgent", 12);
                    Invoke("SpawnAgent", 12);
                    Invoke("SpawnAgent", 12);

                    Invoke("SpawnAgent", 16);
                    Invoke("SpawnAgent", 16);
                    Invoke("SpawnAgent", 16);
                    Invoke("SpawnAgent", 16);

                    Invoke("SpawnAgent", 20);
                    Invoke("SpawnAgent", 20);
                    Invoke("SpawnAgent", 20);

                    Invoke("SpawnAgent", 24);
                    Invoke("SpawnAgent", 24);
                    Invoke("SpawnAgent", 24);
                    Invoke("SpawnAgent", 24);

                    Invoke("SpawnAgent", 28);
                    Invoke("SpawnAgent", 28);
                    Invoke("SpawnAgent", 28);
                    Invoke("SpawnAgent", 28);

                    Invoke("SpawnAgent", 32);
                    Invoke("SpawnAgent", 32);
                    Invoke("SpawnAgent", 32);

                    Invoke("SpawnAgent", 36);
                    Invoke("SpawnAgent", 36);
                    spawned = true;
                }

                if (timer > 36)
                {
                    enemyCheck();
                }
            }
            if (wave == 20)
            {
                if (spawned == false)
                {
                    Invoke("SpawnJoe", 4);
                    spawned = true;
                }

                if (timer > 4)
                {
                    enemyCheck();
                }
            }
            if (wave == 21)
            {
                state += 1;
            }
        }
        if (state == 3)
        {

        }
    }

    void SpawnAgent() {
        GameObject a1 = Instantiate(agent);
        a1.transform.position = SpawnPoint.position;
        a1.GetComponent<EnemyMovement>().safe = safe;
        a1.GetComponent<EnemyMovement>().player = player_b;
        a1.GetComponent<EnemyMovement>().gm = gm;
    }

    void SpawnMech()
    {
        GameObject m1 = Instantiate(mech);
        m1.transform.position = SpawnPoint.position;
        m1.GetComponent<MechMovement>().safe = safe;
        m1.GetComponent<MechMovement>().player = player_b;
        m1.GetComponent<MechMovement>().gm = gm;
    }

    void SpawnJoe()
    {
        GameObject j1 = Instantiate(joe);
        j1.transform.position = SpawnPoint.position;
        j1.GetComponent<MechMovement>().safe = safe;
        j1.GetComponent<MechMovement>().player = player_b;
        j1.GetComponent<MechMovement>().gm = gm;
    }

    void enemyCheck()
    {
        object[] obj = FindObjectsOfType(typeof(GameObject));
        int n = 0;
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
           if (g.tag == "enemy")
            {
                n += 1;
            }
        }
        if (n == 0)
        {
            wave += 1;
            spawned = false;
            timer = 0;
        }
    }

}
