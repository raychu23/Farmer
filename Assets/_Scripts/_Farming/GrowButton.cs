using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowButton : MonoBehaviour
{
    public Farm[] plots;
    public GameObject gameController;
    public GameObject waterSelector;

    private void Start()
    {
        if (!Global.rained || Global.season < 4)
        {
            this.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    public void GrowCrops()
    {
        waterSelector.SetActive(false);
        for(int i = 0; i < plots.Length; i++)
        {
            if (Global.planted[i])
            {
                Global.models[i].SetPest(i + 1);
                gameController.GetComponent<PlantGrowth>().GrowPlant(plots[i]);

            }
        }
        this.gameObject.SetActive(false);
    }

}
