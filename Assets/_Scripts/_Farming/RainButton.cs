using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainButton : MonoBehaviour
{
    public GameObject rain;
    public GameObject growButton;
    public DataInput table;
    public Info infoCanvas;

    private void Start()
    {
        this.gameObject.SetActive(true);


        int planted = 0;

        for(int i = 0; i < Global.planted.Length; i++)
        {
            if (Global.planted[i])
            {
                planted++;
            }
        }

        if(planted == 0 || Global.rained)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void StartRain()
    {
        rain.GetComponent<Rain>().GetRain();
        Global.rained = true;
        if(Global.season > 3)
        {
            growButton.SetActive(true);
        }
        Global.renderRainData = true;
        this.gameObject.SetActive(false);
    }

    public void InfoCanvas()
    {
        if(Global.season == 4)
        {
            infoCanvas.DroughtInfo();
        }
    }
}
