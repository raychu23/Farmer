using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShirt3 : MonoBehaviour
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
		Sale.currentclick = "shirt3";
		Debug.Log(Sale.currentclick);
	}
}
