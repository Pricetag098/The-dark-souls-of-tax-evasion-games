using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPanel : MonoBehaviour
{
	public BuildSlot buildSlot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnMouseOver()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			buildSlot.OnUpGrade();
		}
	}
}
