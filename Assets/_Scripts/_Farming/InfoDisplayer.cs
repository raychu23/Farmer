using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoDisplayer : MonoBehaviour
{
    public TextMeshProUGUI cropText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI nitrateText;

    private void Update()
    {
        if(Global.season >= 8)
        {
            nitrateText.gameObject.SetActive(true);
        }
    }

    public void SetText(int plot)
    {
        if(Global.croptype[Global.season - 1, plot - 1] == 0)
        {
            cropText.SetText("Crop: None");

        }
        else
        {
            if (Global.croptype[Global.season - 1, plot - 1] == 1)
            {

                cropText.SetText("Crop: Corn");
            }
            if (Global.croptype[Global.season - 1, plot - 1] == 2)
            {

                cropText.SetText("Crop: Bean");
            }
            if (Global.croptype[Global.season - 1, plot - 1] == 3)
            {

                cropText.SetText("Crop: Mystery");
            }
        }
        waterText.SetText("Water: " + (Global.raindata[Global.season - 1] + Global.wateradded[Global.season - 1, plot - 1]).ToString());

        if (Global.season == 1)
        {
            nitrateText.SetText("Nitrate: 100");

        }
        else
        {
            nitrateText.SetText("Nitrate: " + Global.models[plot - 1].GetNitrateLevel());
        }
    }
}
