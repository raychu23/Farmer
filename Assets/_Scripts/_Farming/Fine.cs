using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fine : MonoBehaviour
{
    private TextMeshProUGUI seasonText;
    private TextMeshProUGUI desText;

    public GameObject dataButton;
    public GameObject plotButton;
    public GameObject inventory;
    public GameObject boxDisplay;
    public GameObject fineCanvas;

    public void CalculateFine(int fert, bool[,] pest)
    {
        pest = Global.pestUsed;
        int pestCounter = 0;
        for(int i = 0; i < 6; i++)
        {
            if(Global.pestUsed[Global.season-1, i])
            {
                pestCounter++;
            }
        }

        if (Global.season > 12)
        {
            bool fine = false;
            int num = Random.Range(0, 100);

            if(fert + pestCounter < 6)
            {
                fine = false;
            }
            else if (fert + pestCounter <= 10)
            {
                if(num < 20)
                {
                    fine = true;
                }
            }
            else if (fert + pestCounter <= 20)
            {
                if (num < 50)
                {
                    fine = true;
                }
            }
            else
            {
                fine = true;
            }


            if (fine)
            {
                fineCanvas.SetActive(true);
                inventory.SetActive(false);
                boxDisplay.SetActive(false);
                dataButton.SetActive(false);
                plotButton.SetActive(false);
            }
        }
    }
}

