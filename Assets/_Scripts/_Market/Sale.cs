using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sale : MonoBehaviour
{
    public GameObject price;
	public GameObject table2;
	public GameObject table3;
    public GameObject lock1;
    public GameObject lock2;

    private bool appear;
    public static string currentclick = "none";
	// Start is called before the first frame update
	void Start()
    {
		price.SetActive(false);
		table2.SetActive(false);
		table3.SetActive(false);
        lock1.SetActive(false);
        lock2.SetActive(false);
		appear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnMouseDown(){
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Clicked on the UI");
        }
        else
        {
            GameObject.Find("Sound").GetComponent<Sound>().PlayButtonSound();
            if (!appear)
            {
                price.SetActive(true);
				table2.SetActive(false);
				table3.SetActive(false);
                lock1.SetActive(false);
                lock2.SetActive(false);
                appear = true;
            }
            else
            {
                price.SetActive(false);
                appear = false;
            }

            currentclick = "none";
        }
    }
}
