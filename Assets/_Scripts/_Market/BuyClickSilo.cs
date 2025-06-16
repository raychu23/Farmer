using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyClickSilo : MonoBehaviour
{
    public GameObject errormessage;
    public GameObject refund;
    public static bool isbought = false;
    public Sound sound;
    public GameObject hovering;
	// Start is called before the first frame update
	void Start()
	{
		hovering.SetActive(false);
		errormessage.SetActive(false);
		refund.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
		if (isbought)
		{
			hovering.SetActive(false);
			refund.SetActive(true);
		}
		else
		{
			hovering.SetActive(true);
			refund.SetActive(false);
		}
    }
    private void OnMouseExit()
    {
		if(isbought)
		{
			hovering.SetActive(false);
			refund.SetActive(false);
		}
		else
		{
			hovering.SetActive(false);
			refund.SetActive(false);
		}
	}

    void OnMouseDown()
    {
        Sale.currentclick = "silo";
        Debug.Log(Sale.currentclick);
		if (!isbought)
		{
			if (Global.gold < 500)
			{
				errormessage.SetActive(true);
			}
			else
			{
				sound.PlayCoinSound();
				Global.gold -= 500;
				Global.silo = true;
				isbought = true;
			}
		} else
		{
			Global.gold += 400;
			Global.silo = false;
			isbought = false;
		}
    }
}
