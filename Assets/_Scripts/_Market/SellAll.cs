using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellAll : MonoBehaviour
{
	public GameObject thisbutton;
	public GameObject selection;
	public GameObject errormessage;
	private int amount;
	private int total;

	// Start is called before the first frame update
	void Start()
	{
		errormessage.SetActive(false);
    }

    private void Update()
    {
        this.gameObject.SetActive(true);
        if (Sale.currentclick != "sale" && Sale.currentclick != "sale1" && Sale.currentclick != "sale2" &&
            Sale.currentclick != "saleseed" && Sale.currentclick != "saleseed1" && Sale.currentclick != "saleseed2")
        {
            this.gameObject.SetActive(false);
        }
    }


    public void sellall()
    {
        // crops
		if (Sale.currentclick == "sale")
		{
			amount = Global.crops;
			if (amount == 0)
			{
				errormessage.SetActive(true);
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
				Global.crops = 0;
				Global.gold += total;
			}
		}//corn

		if (Sale.currentclick == "sale1")
		{
			amount = Global.crops2;
			if (amount == 0)
			{
				errormessage.SetActive(true);
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
				Global.crops2 = 0;
				Global.gold += total;
			}
		}//bean

		if (Sale.currentclick == "sale2")
		{
			amount = Global.crops3;
			if (amount == 0)
			{
				errormessage.SetActive(true);
			}
			else
			{
				total = amount * 20;
				Global.crops3 = 0;
				Global.gold += total;
			}
		}//carrot


        // seeds
		if (Sale.currentclick == "saleseed")
		{
			amount = Global.seeds;
			if (amount == 0)
			{
				errormessage.SetActive(true);
			}
			else
			{
				total = amount * 8;
				Global.seeds = 0;
				Global.gold += total;
			}
		}//corn

		if (Sale.currentclick == "saleseed1")
		{
			amount = Global.seeds2;
			if (amount == 0)
			{
				errormessage.SetActive(true);
			}
			else
			{
				total = amount * 4;
				Global.seeds2 = 0;
				Global.gold += total;
			}
		}//bean

		if (Sale.currentclick == "saleseed2")
		{
			amount = Global.seeds3;
			if (amount == 0)
			{
				errormessage.SetActive(true);
			}
			else
			{
				total = amount * 8;
				Global.seeds = 0;
				Global.gold += total;
			}
		}//carrot

		selection.SetActive(false);
    }
}
