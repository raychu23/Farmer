using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowthTut : MonoBehaviour
{
    public void GrowPlant(FarmTut plot)
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
