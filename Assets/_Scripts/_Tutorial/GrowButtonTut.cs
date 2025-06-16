using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowButtonTut : MonoBehaviour
{
    public FarmTut[] plots;
    public GameObject gameController;
    public GameObject waterSelector;

    private void Update()
    {
        if (TutorialGlobal.instructionNum != 8)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    // Start is called before the first frame update
    public void GrowCrops()
    {
        waterSelector.SetActive(false);
        for (int i = 0; i < plots.Length; i++)
        {
            if (TutorialGlobal.planted[i])
            {
                gameController.GetComponent<PlantGrowthTut>().GrowPlant(plots[i]);
            }
        }
        this.gameObject.SetActive(false);

    }


}
