using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public GameObject pests;
    //public GameObject pesticides;

    public void GrowPlant(Farm plot)
    {
        if (plot.GetPlantType() == 1)
        {
            StartCoroutine(plot.Grow(1));
        }
        else if (plot.GetPlantType() == 2)
        {
            StartCoroutine(plot.Grow(2));
        }
        else
        {
            StartCoroutine(plot.Grow(3));
        }
    }
}
