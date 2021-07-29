using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_AgentSpawner : MonoBehaviour
{
    public GameObject Agent,player,safe;

    public float spamOdds;
    GameObject currentAgent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spamOdds > 0)
        {
            if(Random.value < spamOdds)
            {
                currentAgent = Instantiate(Agent, transform.position, transform.rotation, transform);
				if (currentAgent.GetComponent<EnemyMovement>())
				{
					currentAgent.GetComponent<EnemyMovement>().player = player;
					currentAgent.GetComponent<EnemyShooting>().player = player;
					currentAgent.GetComponent<EnemyMovement>().safe = safe;
				}

				if (currentAgent.GetComponent<MechMovement>())
				{
					currentAgent.GetComponent<MechMovement>().player = player;
					//currentAgent.GetComponent<EnemyShooting>().player = player;
					currentAgent.GetComponent<MechMovement>().safe = safe;
				}
            }
        }

        if (currentAgent)
        {
            return;
        }
        else
        {
            currentAgent = Instantiate(Agent,transform.position,transform.rotation,transform);
			if (currentAgent.GetComponent<EnemyMovement>())
			{
				currentAgent.GetComponent<EnemyMovement>().player = player;
				currentAgent.GetComponent<EnemyShooting>().player = player;
				currentAgent.GetComponent<EnemyMovement>().safe = safe;
			}
			if (currentAgent.GetComponent<MechMovement>())
			{
				currentAgent.GetComponent<MechMovement>().player = player;
				//currentAgent.GetComponent<EnemyShooting>().player = player;
				currentAgent.GetComponent<MechMovement>().safe = safe;
			}
		}
    }
}
