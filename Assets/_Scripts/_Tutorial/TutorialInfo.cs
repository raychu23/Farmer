using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialInfo : MonoBehaviour
{
	private TextMeshProUGUI seasonText;
	private TextMeshProUGUI desText;

	public GameObject inventory;

	//Descriptions of each season
	public string[] seasonDesc = new string[6];

	// Start is called before the first frame update
	void Start()
	{
		
        desText = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

		//Set the season and description
		// this.seasonText.SetText("Season " + Global.season.ToString());
        if (TutorialGlobal.season == 1)
		{
			this.desText.SetText(seasonDesc[0]);
			this.gameObject.SetActive(true);
			inventory.SetActive(false);
		}
		else if (TutorialGlobal.season == 2)
		{
			this.desText.SetText(seasonDesc[1]);
			this.gameObject.SetActive(true);
			inventory.SetActive(false);
		}
		else
		{
			this.gameObject.SetActive(false);
			inventory.SetActive(true);
		}

	}

	public void RenderInfo()
	{
		
        this.gameObject.SetActive(true);
        inventory.SetActive(false);
        desText = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

		if (TutorialGlobal.season == 1)
		{
			this.desText.SetText(seasonDesc[0]);
			this.gameObject.SetActive(true);
			inventory.SetActive(false);
		}

		if (TutorialGlobal.season == 2)
        {
            this.desText.SetText(seasonDesc[1]);
            this.gameObject.SetActive(true);
            inventory.SetActive(false);
        }
       
	}
}
