using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BSPanel : MonoBehaviour
{
	public BuildSlot buildSlot;

	public TextMeshPro infoText,costText;

	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if(buildSlot.lvl == 0)
		{
			infoText.text = "Press E to build: " + buildSlot.type.ToString();
		}
		else if(buildSlot.lvl > buildSlot.tParent.childCount)
		{
			infoText.text = "Max lvl";
		}
		else
		{
			infoText.text = "Press E to upgrade: " + buildSlot.type.ToString();
		}
		if(buildSlot.lvl >= buildSlot.tParent.childCount)
		{
			costText.text = "Cost: N/A";
		}
		else
		{
			costText.text = "Cost: " + buildSlot.nextCost.ToString();
		}
		
    }
	private void OnMouseOver()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			buildSlot.OnUpGrade();
		}
	}
}
