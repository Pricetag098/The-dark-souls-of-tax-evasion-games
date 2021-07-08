using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSlot : MonoBehaviour
{
	public int lvl;
	public Transform tParent;
    // Start is called before the first frame update
    void Start()
    {
		
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
		lvl += 1;
	}


}
