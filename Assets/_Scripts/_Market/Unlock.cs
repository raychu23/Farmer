using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
	public GameObject unlockmessage;
	private bool appear;

    // Start is called before the first frame update
    void Start()
    {
		unlockmessage.SetActive(false);
		appear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
	{
        GameObject.Find("Sound").GetComponent<Sound>().PlayButtonSound();
        if (!appear)
		{
			unlockmessage.SetActive(true);
			appear = true;
		}
		else
		{
			unlockmessage.SetActive(false);
			appear = false;
		}
	}
}
