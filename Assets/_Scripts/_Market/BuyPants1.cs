using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPants1 : MonoBehaviour
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
		Sale.currentclick = "pants1";
		Debug.Log(Sale.currentclick);
	}
}
