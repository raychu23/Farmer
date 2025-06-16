using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesInfo : MonoBehaviour
{
	public GameObject info;
	private static bool displayed = false;

    // Start is called before the first frame update
    void Start()
    {
		info.SetActive(false);
    }

    void OnMouseDown()
	{
        if (!displayed && Global.season < 7)
		{
            GameObject.Find("Sound").GetComponent<Sound>().PlayButtonSound();
            info.SetActive(true);
			displayed = true;
		}
  	}
}
