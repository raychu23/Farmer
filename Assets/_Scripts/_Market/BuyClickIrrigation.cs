using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyClickIrrigation : MonoBehaviour
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
        if (isbought)
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
        Sale.currentclick = "irrigation";
        Debug.Log(Sale.currentclick);
        if (!isbought)
        {
            if (Global.gold < 3000)
            {
                errormessage.SetActive(true);
            }
            else
            {
                sound.PlayCoinSound();
                Global.gold -= 3000;
                Global.irrigation = true;
                isbought = true;
            }
        }
        else
        {
            Global.gold += 2000;
            Global.irrigation = false;
            isbought = false;
        }
    }
}
