using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SellSeedAmountSubmit : MonoBehaviour
{
    public GameObject selection;
    public GameObject amountInput;
    public GameObject errortext;
    public GameObject negativeamounttext;
    private int amount;
    private int total;

    void Start()
    {
        errortext.SetActive(false);
        negativeamounttext.SetActive(false);
    }

    public void GetAmount()
    {
        amount = amountInput.GetComponent<AmountInput>().GetAmount();

        if (Sale.currentclick == "sale" || Sale.currentclick == "sale1" || Sale.currentclick == "sale2")
        {
            errortext.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText("You don't have enough crops to sell.");
        }
        else if (Sale.currentclick == "saleseed" || Sale.currentclick == "saleseed1" || Sale.currentclick == "saleseed2")
        {
            errortext.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText("You don't have enough seeds to sell.");
        }
        else
        {
            errortext.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText("You don't have enough money to make this purchase.");
        }

        if (amount < 0)
        {
            negativeamounttext.SetActive(true);
        }
        else
        {
            // sell seeds
            if (Sale.currentclick == "buy")
            {
                if (Global.seeds < amount)
                {
                    errortext.SetActive(true);
                }
                else
                {
                    total = amount * 8;
                    Global.seeds -= amount;
                    Global.gold += total;
                }
            }//corn

            if (Sale.currentclick == "buy1")
            {
                if (Global.seeds2 < amount)
                {
                    errortext.SetActive(true);
                }
                else
                {
                    total = amount * 4;
                    Global.seeds2 -= amount;
                    Global.gold += total;
                }
            }//bean

            if (Sale.currentclick == "buy2")
            {
                if (Global.seeds3 < amount)
                {
                    errortext.SetActive(true);
                }
                else
                {
                    total = amount * 8;
                    Global.seeds3 -= amount;
                    Global.gold += total;
                }
            }//carrot


            //Reset amount to 0
            amountInput.GetComponent<AmountInput>().Reset();
            selection.SetActive(false);
        }
    }
}
