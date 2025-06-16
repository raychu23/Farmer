using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleClick1 : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject hovering;
    // Start is called before the first frame update
    void Start()
    {
        hovering.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.season == 17)
        {
			Global.currBeanCrop = 2;
            
        }
        else if (Global.season == 18)
        {
			Global.currBeanCrop = 8;
            
		}
		else
		{
			Global.currBeanCrop = 10;
		}
    }
    private void OnMouseOver()
    {
        hovering.SetActive(true);
    }
    private void OnMouseExit()
    {
        hovering.SetActive(false);
    }
    void OnMouseDown()
	{
        Sale.currentclick = "sale1";
        Debug.Log(Sale.currentclick);
    }
}
