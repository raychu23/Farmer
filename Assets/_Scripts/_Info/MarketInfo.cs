using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarketInfo : MonoBehaviour
{

    public GameObject inventory;

	public GameObject buttons;
    


    // Start is called before the first frame update
    void Start()
    {
        if (Global.season == 2)
        {
            Debug.Log("season 2");
            //Make this the first screen 
            this.gameObject.SetActive(true);
            //Disable inventory b/c it overlaps
            inventory.SetActive(false);
            buttons.SetActive(false);
            Debug.Log("set them not active");
        }
        else
        {
            this.gameObject.SetActive(false);
            inventory.SetActive(true);
            buttons.SetActive(true);
        }
    }
}
