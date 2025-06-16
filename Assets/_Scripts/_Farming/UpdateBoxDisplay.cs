using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateBoxDisplay : MonoBehaviour
{
    public TextMeshProUGUI amountObj;
    public TextMeshProUGUI seasonObj;

    private void Start()
    {
        seasonObj.SetText("Season " + Global.season.ToString());
        amountObj.SetText(Global.raindata[Global.season-1].ToString());
    }

    public void UpdateAmount(int amount)
    {
        amountObj.SetText(amount.ToString());
    }

    public void UpdateSeason(int season)
    {
        seasonObj.SetText("Season " + season.ToString());
        amountObj.SetText("0");
    }
}
