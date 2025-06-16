using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmountSubmit : MonoBehaviour
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

            // buy seeds
            if (Sale.currentclick == "buy")
            {
                total = amount * 10;
                if (Global.gold < total)
                {
                    errortext.SetActive(true);
                }
                else
                {
                    Global.gold -= total;
                    Global.seeds += amount;
                }
            }//corn

            if (Sale.currentclick == "buy1")
            {
                total = amount * 6;
                if (Global.gold < total)
                {
                    errortext.SetActive(true);
                }
                else
                {
                    Global.gold -= total;
                    Global.seeds2 += amount;
                }
            }//bean

            if (Sale.currentclick == "buy2")
            {
                total = amount * 10;
                if (Global.gold < total)
                {
                    errortext.SetActive(true);
                }
                else
                {
                    Global.gold -= total;
                    Global.seeds3 += amount;
                }
            }//carrot



            // sell crops
            if (Sale.currentclick == "sale")
            {
                if (Global.crops < amount)
                {
                    errortext.SetActive(true);
                }
                else
                {
                    if (Global.season == 17)
                    {
                        total = amount * 20;
                    }
                    else if (Global.season == 18)
                    {
                        total = amount * 10;
                    }
                    else
                    {
                        total = amount * 5;
                    }
                    Global.crops -= amount;
                    Global.gold += total;
                }
            }//corn

            if (Sale.currentclick == "sale1")
            {
                if (Global.crops2 < amount)
                {
                    errortext.SetActive(true);
                }
                else
                {
                    if (Global.season == 17)
                    {
                        total = amount * 2;
                    }
                    else if (Global.season == 18)
                    {
                        total = amount * 8;
                    }
                    else
                    {
                        total = amount * 10;
                    }
                    Global.crops2 -= amount;
                    Global.gold += total;
                }
            }//bean

            if (Sale.currentclick == "sale2")
            {
                if (Global.crops3 < amount)
                {
                    errortext.SetActive(true);
                }
                else
                {
                    total = amount * 20;
                    Global.crops3 -= amount;
                    Global.gold += total;
                }
            }//carrot


            /*
            // sell seeds
            if (Sale.currentclick == "saleseed")
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

            if (Sale.currentclick == "saleseed1")
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

            if (Sale.currentclick == "saleseed2")
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

    */

            // tools
            if (Sale.currentclick == "water")
            {
                if (Global.season > 3)
                {
                    if (Global.season == 16 || Global.season == 17)
                    {
                        total = 5 * amount;
                    }
                    else if (Global.season > 17)
                    {
                        total = 2 * amount;
                    }
                    else
                    {
                        total = amount;
                    }
                    if (Global.gold < total)
                    {
                        errortext.SetActive(true);
                    }
                    else
                    {
                        Global.gold -= total;
                        Global.water += amount;

                        //Water quest
                        if(Global.season >= 14 && !Global.canClaim[6])
                        {
                            Global.waterCounter += amount;
                        }
                    }
                }
            }//water

            if (Sale.currentclick == "fertilizer")
            {
                if (Global.season > 9)
                {
                    total = amount * 10;
                    if (Global.gold < total)
                    {
                        errortext.SetActive(true);
                    }
                    else
                    {
                        Global.gold -= total;
                        Global.fertilizer += amount;
                    }
                }
            }//fertilizer

            if (Sale.currentclick == "pesticide")
            {
                if (Global.season > 19)
                {
                    total = amount * 5;
                    if (Global.gold < total)
                    {
                        errortext.SetActive(true);
                    }
                    else
                    {
                        Global.gold -= total;
                        Global.pesticides += amount;
                    }
                }
            }//pesticide

            //Reset amount to 0
            amountInput.GetComponent<AmountInput>().Reset();
            selection.SetActive(false);
        }
    }
}
