using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponRackPanel : MonoBehaviour
{
	public Transform holster;
	public GameObject GunModel;
	public int cost;
	public GameObject parentPanel;

	MeshRenderer panel;
	TMP_Text info, costTxt;
	public Material[] mats;

	private void Start()
	{
		panel = parentPanel.transform.GetChild(0).GetComponent<MeshRenderer>();
		info = parentPanel.transform.GetChild(1).GetComponent<TMP_Text>();
		costTxt = parentPanel.transform.GetChild(2).GetComponent<TMP_Text>();
		costTxt.text = cost.ToString();
		panel.enabled = false;
		info.enabled = false;
		costTxt.enabled = false;
	}

	// Start is called before the first frame update
	private void OnMouseOver()
	{
		panel.enabled = true;
		info.enabled = true;
		costTxt.enabled = true;

		if (cost <= Money.money)
		{
			panel.material = mats[1];
			if (Input.GetKeyDown(KeyCode.E))
			{
				Money.money -= cost;
				GameObject NewGun = Instantiate(GunModel, holster.position, holster.rotation, holster);
				NewGun.GetComponentInChildren<Gun>().head = holster.parent;
				NewGun.SetActive(false);
				Destroy(gameObject);
			}
		}
		else
		{
			panel.material = mats[0];
		}
	}
	private void OnMouseExit()
	{
		panel.enabled = false;
		info.enabled = false;
		costTxt.enabled = false;
	}
}
