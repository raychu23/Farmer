using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPants3 : MonoBehaviour
{
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnMouseDown()
	{
		Sale.currentclick = "pants3";
		Debug.Log(Sale.currentclick);
	}
}
