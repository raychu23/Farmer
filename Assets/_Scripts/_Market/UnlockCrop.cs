using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnlockCrop : MonoBehaviour
{
	public GameObject lock1;
    public GameObject errormessage;
	public static bool islock = true;
    public GameObject hovering;

	// Start is called before the first frame update
	void Start()
	{
		lock1.SetActive(true);
		errormessage.SetActive(false);
        hovering.SetActive(false);
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
		if (islock && Global.season > 5 && !EventSystem.current.IsPointerOverGameObject())
		{
			if (Global.gold < 400)
			{
                GameObject.Find("Sound").GetComponent<Sound>().PlayButtonSound();
                errormessage.SetActive(true);
			}
			else
			{
                GameObject.Find("Sound").GetComponent<Sound>().PlayCoinSound();
				Global.gold -= 400;
				lock1.SetActive(false);
				islock = false;
			}
		}
	}
}
