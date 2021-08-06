using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSlot : MonoBehaviour
{
	public int lvl;
	public Transform tParent;

	public enum Types { gun, rocket, health, other};
	public Types type;

	public int nextCost;
	public Dictionary<int, int> costDict = new Dictionary<int, int>();
	// Start is called before the first frame update
	void Start()
    {
		
		switch (type)
		{
			case Types.gun:
				{
					costDict.Add(0, 100);
					costDict.Add(1, 500);
					costDict.Add(2, 1000);
					break;
				}
			case Types.rocket:
				{
					costDict.Add(0, 500);
					costDict.Add(1, 1200);
					break;
				}
            case Types.health:
                {
                    costDict.Add(0, 500);
                    break;
                }

		}
		nextCost = costDict[lvl];
	}

    // Update is called once per frame
    void Update()
    {

		for (int i = 0; i < tParent.childCount; i++)
		{
			tParent.GetChild(i).gameObject.SetActive(i + 1 == lvl);
			
		}
	}

	public void OnUpGrade()
	{
		if(Money.money >= nextCost)
		{
            if(lvl < tParent.childCount)
            {
				Money.money -= nextCost;
                lvl++;
            }
            if (lvl < tParent.childCount-1)
			{
				
				nextCost = costDict[lvl];
			}
		}
		
		
	}


}
