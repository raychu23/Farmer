using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellAllCrops : MonoBehaviour
{
	public GameObject button;
    public GameObject table;
	private int crop1;
	private int crop2;
	private int crop3;
	private int total;

    // Start is called before the first frame update
    void Start()
    {
		//button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UnlockCrop.islock && UnlockCrop2.islock2)
		{
			button.SetActive(false);
		}
		else
		{
			button.SetActive(true);
		}
		crop1 = Global.crops;
		crop2 = Global.crops2;
		crop3 = Global.crops3;
    }

    void OnMouseDown()
	{
        if (Global.season == 17)
        {
            total = 20 * crop1 + 2 * crop2 + 20 * crop3;
        }
        else if (Global.season == 18)
        {
            total = 10 * crop1 + 8 * crop2 + 2 * crop3;
        }
        else
        {
            total = 5 * crop1 + 10 * crop2 + 20 * crop3;
        }
		Global.crops = 0;
		Global.crops2 = 0;
		Global.crops3 = 0;
		Global.gold += total;
        table.SetActive(false);
	}
}
