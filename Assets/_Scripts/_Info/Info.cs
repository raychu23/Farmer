using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Info : MonoBehaviour
{
    private TextMeshProUGUI seasonText;
    private TextMeshProUGUI desText;

    public GameObject dataButton;
    public GameObject plotButton;
    public GameObject inventory;
    public GameObject boxDisplay;
    public GameObject saveButton;
    public GameObject menuButton;
    public GameObject questButton;

    //Descriptions of each season
    public string[] seasonDesc = new string[6];

    private void Start()
    {
        if(Global.season != 1)
        {
            this.gameObject.SetActive(false);
            inventory.SetActive(true);
            boxDisplay.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(true);
            inventory.SetActive(false);
            boxDisplay.SetActive(false);
        }
    }

    public void GameOver()
    {
        desText = this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        this.desText.SetText(seasonDesc[4]);
        this.gameObject.SetActive(true);
        inventory.SetActive(false);
        dataButton.SetActive(false); 
        plotButton.SetActive(false);
        saveButton.SetActive(false);
        menuButton.SetActive(false);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }

    public void RenderInfo()
    {
        desText = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        if(Global.season == 2)
        {
            int corn = 0;

            for (int i = 0; i < 6; i++)
            {
                corn += Mathf.RoundToInt(Global.yielddata[0, i]);
            }
            Debug.Log("info");
            this.desText.SetText("You have harvested your first crop: " + corn + " bushels of corn! Go to the market to sell your corn, buy new items and meet some people.");
            this.gameObject.SetActive(true);
            HideObjects();
        }
        else if (Global.season == 4)
        {
            this.desText.SetText(seasonDesc[1]);
            this.gameObject.SetActive(true);
            HideObjects();
        }
        else if (Global.season == 6 || Global.season == 9)
        {
            this.desText.SetText(seasonDesc[3]);
            this.gameObject.SetActive(true);
            HideObjects();
        }
        else if (Global.season == 10)
        {
            this.desText.SetText(seasonDesc[5]);
            this.gameObject.SetActive(true);
            HideObjects();
        }
        else if (Global.season == 11)
        {
            this.desText.SetText(seasonDesc[6]);
            this.gameObject.SetActive(true);
            HideObjects();
        }
        else if(Global.season == 20)
        {
            this.desText.SetText(seasonDesc[7]);
            this.gameObject.SetActive(true);
            HideObjects();
        }
    }

    public void DroughtInfo()
    {
        this.gameObject.SetActive(true);
        desText = this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        desText.SetText(seasonDesc[2]);
        HideObjects();
    }

    private void HideObjects()
    {
        inventory.SetActive(false);
        dataButton.SetActive(false);
        plotButton.SetActive(false);
        saveButton.SetActive(false);
        menuButton.SetActive(false);
        questButton.SetActive(false);
    }
}
