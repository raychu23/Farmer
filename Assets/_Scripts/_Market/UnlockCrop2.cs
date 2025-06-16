using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnlockCrop2 : MonoBehaviour
{
	public GameObject lock2;
	public GameObject errormessage;
    public GameObject hovering;
	public static bool islock2 = true;

	// Start is called before the first frame update
	void Start()
    {
		lock2.SetActive(true);
		errormessage.SetActive(false);
        hovering.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
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
		if (islock2 && Global.season > 8 && !EventSystem.current.IsPointerOverGameObject())
		{
			if (Global.gold < 1000)
			{
				errormessage.SetActive(true);
			}
			else
			{
				Global.gold -= 1000;
				lock2.SetActive(false);
				islock2 = false;
			}
		}
	}
}
