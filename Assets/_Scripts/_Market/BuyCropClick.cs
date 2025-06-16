using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCropClick : MonoBehaviour
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
		Sale.currentclick = "buycrop";
		Debug.Log(Sale.currentclick);
	}
}
