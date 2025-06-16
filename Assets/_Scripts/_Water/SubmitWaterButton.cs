using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitWaterButton : MonoBehaviour
{

    public GameObject amountInput;
    public GameObject waterSlot;
    public GameObject waterError;
    public Sound sound;
    public GameObject negError;


   // private Farm plot;
    //private Models model;

    private int amount;
    public GameObject waterDisplay;
    public GameObject irrDisplay;
    public GameObject gameController;
    

    //Each index represents if a plot is selected or n
    public Farm[] plots;

    private void Update()
    {
        amountInput.GetComponent<InputField>().ActivateInputField();
    }

    public void GetWater()
    {
        amount = amountInput.GetComponent<WaterInput>().GetAmount();

        if (amount < 0)
        {
            negError.SetActive(true);
        }
        else
        {
            if (Global.irrigation && (Global.water < Mathf.RoundToInt(amount / 2f) * GetNumSelected()))
            {
                waterError.SetActive(true);
            }
            else if (!Global.irrigation && (Global.water < amount * GetNumSelected()))
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

                        if (Global.irrigation)
                        {
                            plots[i].model.AddWater(amount);
                            Global.wateradded[Global.season - 1, i] = amount + Global.wateradded[Global.season - 1, i];
                            waterDisplay.GetComponent<Display>().DisplayResource((amount * GetNumSelected()).ToString());
                            irrDisplay.GetComponent<Display>().DisplayResource((Mathf.RoundToInt(amount / 2.0f) * GetNumSelected()).ToString());
                            Global.water -= Mathf.RoundToInt(amount / 2.0f);
                        }
                        else
                        {
                            plots[i].model.AddWater(amount);
                            Global.wateradded[Global.season - 1, i] = amount + Global.wateradded[Global.season - 1, i];
                            waterDisplay.GetComponent<Display>().DisplayResource((amount * GetNumSelected()).ToString());
                            Global.water -= amount;
                        }

                    }
                }
                //Reset amount to 0
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
