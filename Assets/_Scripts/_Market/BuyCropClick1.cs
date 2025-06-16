using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCropClick1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnMouseDown()
	{
		Sale.currentclick = "buycrop1";
		Debug.Log(Sale.currentclick);
	}
}
