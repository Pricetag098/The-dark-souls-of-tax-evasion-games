using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject agent;
    public GameObject mech, joe;
    public GameObject safe;
    public GameObject player_b, player, holster;
    public int wave;
    public float lives;
    public int state;
    public bool spawned;
    private float timer;
    public GameManager gm;
    public TextMeshProUGUI message;
    public Health p_health;
    public float respawn_timer;


    // Start is called before the first frame update
    void Start()
    {
        lives = 100000000;
        wave = 1;
        state = 1;
        spawned = false;
        timer = 0;
        respawn_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (state == 1)
        {
            if (timer < 5)
            {
                message.text = "Welcome to the Dark Souls of Tax Evasion Games";
            }
            if (timer < 10 && timer > 5)
            {
                message.text = "You have escaped to the moon to avoid paying your taxes, but the IRS is coming for you";
            }
            if (timer < 15 && timer > 10)
            {
                message.text = "They want to reclaim your tax money in the safe to your left, so you must defend it";
            }
            if (timer < 20 && timer > 15)
            {
                message.text = "Use the guns in the gun rack to your right, as well as building defence towers along the track to fend off the IRS wave by wave";
            }
            if (timer > 25)
            {
                state += 1;
                message.text = "The IRS is coming...";
                timer = 0;
            }
        }
        if (state == 2)
        {
            if (timer > 5)
            {
                message.text = "";
            }
            if (p_health.health <= 0)
            {
                respawn_timer += Time.deltaTime;
                player_b.SetActive(false);
                holster.SetActive(false);
                message.text = "You have died, respawning in 5 seconds";
                print("ded");
                print(respawn_timer);
                if (respawn_timer > 5)
                {

                    print("greater than 5");
                    p_health.health = 10000;
                    player_b.transform.localPosition = new Vector3(0, 0, 0);
                    holster.SetActive(true);
                    player_b.SetActive(true);
                    message.text = "";
                    respawn_timer = 0;
                }
                
                

            }
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
                    message.text = "";
                }
                else
                {
                    message.text = "Joe Biden approaches...";
                }
            }
            if (wave == 21)
            {
                state += 1;
            }
        }
        if (state == 3)
        {
            message.text = "You Win!";
            Invoke("LoadMenu", 5);
            Time.timeScale = 0;

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

    void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

}
