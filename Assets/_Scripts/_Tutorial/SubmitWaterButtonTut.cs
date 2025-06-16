using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitWaterButtonTut : MonoBehaviour
{

    public GameObject amountInput;
    public GameObject waterSlot;
    public GameObject waterError;
    public GameObject instructions;


    // private Farm plot;
    //private Models model;

    private int amount;
    public GameObject waterDisplay;
    public GameObject gameController;

    //Each index represents if a plot is selected or not
    public bool[] selected;
    public FarmTut[] plots;

    private void Update()
    {
        amountInput.GetComponent<InputField>().ActivateInputField();
    }

    public void GetWater()
    {
        instructions.SetActive(true);
        if(TutorialGlobal.instructionNum == 7)
        {
            GameObject.Find("GameController").GetComponent<TutorialController>().UpdateNum();
        }

        Debug.Log(selected[0]);
        amount = amountInput.GetComponent<WaterInput>().GetAmount();

        if (TutorialGlobal.water < amount * GetNumSelected())
        {
            waterError.SetActive(true);
        }
        else
        {

            for (int i = 0; i < gameController.GetComponent<Multiselect>().plotsSelected.Length; i++)
            {
                //Water plot if it's selected
                if (gameController.GetComponent<Multiselect>().plotsSelected[i])
                {
                    Debug.Log("watering plot " + (i+1));
                    Debug.Log("amount: " + amount);
                    TutorialGlobal.water -= amount;
                    plots[i].model.AddWater(amount);
                    TutorialGlobal.wateradded[TutorialGlobal.season - 1, i] = amount;
                }
            }
            //Reset amount to 0
            waterDisplay.GetComponent<Display>().DisplayResource( (amount * GetNumSelected()).ToString());
            amountInput.GetComponent<WaterInput>().Reset();


            //Set all plots watered to prevWatered;
            for (int i = 1; i < 7; i++)
            {
                if (gameController.GetComponent<Multiselect>().plotsSelected[i - 1])
                {
                    gameController.GetComponent<Multiselect>().PrevSelect(i);
                    gameController.GetComponent<Multiselect>().plotsSelected[i - 1] = false;
                }
            }
            this.transform.parent.gameObject.SetActive(false);
        }
    }


    public int GetNumSelected()
    {
        int counter = 0;
        for (int i = 0; i < gameController.GetComponent<Multiselect>().plotsSelected.Length; i++)
        {
            if (gameController.GetComponent<Multiselect>().plotsSelected[i])
            {
                counter++;
            }
        }
        return counter;
    }
}
