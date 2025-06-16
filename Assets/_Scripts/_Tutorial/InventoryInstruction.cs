using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryInstruction : MonoBehaviour
{
	private TextMeshProUGUI desText;

	public GameObject inventory;

	public string info;

	public GameObject buttons;


	void Start()
	{
		desText = this.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

		if (TutorialGlobal.season == 1)
		{
			this.desText.SetText(info);
			//Make this the first screen 
			this.gameObject.SetActive(true);
			//Disable inventory b/c it overlaps
			inventory.SetActive(false);
			buttons.SetActive(false);
		}
		else
		{
			this.gameObject.SetActive(false);
			inventory.SetActive(true);
			buttons.SetActive(true);
		}
	}

	public void RenderInfo()
	{
		this.gameObject.SetActive(true);
		this.desText.SetText(info);
		inventory.SetActive(false);
		//buttons.SetActive(false);
	}
}
