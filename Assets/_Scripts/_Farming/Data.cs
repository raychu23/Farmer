using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Data : MonoBehaviour
{
    public GameObject rains;
    // public GameObject yields;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

        rains.GetComponent<TextMeshProUGUI>().SetText(Global.data);
        //for (int i = 0; i < Global.season; i++)
        //{
        //    if ((i < Global.season - 1) || (Global.planted1 && Global.planted2))
        //    {
        //        for (int j = 0; j < 2; j++)
        //        {
        //            this.AddYield(Global.yielddata[i, j], i + 1, j + 1, Global.raindata[i], Global.wateradded[i, j], Global.croptype[i,j]);
        //        }
        //    }
        //}

    }

    // Update is called once per frame


    public void AddYield(int yield, int season, int plot, int rain, int wateradded, int croptype)
    {
        Global.data = Global.data + System.Environment.NewLine + "Plot: " + plot.ToString() + "    Season: " + season + "    Rainfall: " + rain.ToString() + "    Total Water: " + (rain + wateradded).ToString() + "    Crop Type: " + croptype.ToString() + "   Yield: " + yield.ToString();
        rains.GetComponent<TextMeshProUGUI>().SetText(Global.data);

    }
}
