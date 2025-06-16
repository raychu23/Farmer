using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleSeedClick1 : MonoBehaviour
{

	void OnMouseDown()
	{
		Sale.currentclick = "saleseed1";
		Debug.Log(Sale.currentclick);
	}
}
