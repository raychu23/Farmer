using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPants2 : MonoBehaviour
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
		Sale.currentclick = "pants2";
		Debug.Log(Sale.currentclick);
	}
}
