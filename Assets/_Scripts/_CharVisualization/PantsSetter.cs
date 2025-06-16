using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantsSetter : MonoBehaviour
{
	public BodyData[] pants;


	// Update is called once per frame
	void Update()
	{
		if (Global.pants == 0)
		{
			this.GetComponent<BodySpriteSwapper>().data = pants[0];
		}
		else if (Global.pants == 1)
		{
			this.GetComponent<BodySpriteSwapper>().data = pants[1];
		}
		else if (Global.pants == 2)
		{
			this.GetComponent<BodySpriteSwapper>().data = pants[2];
		}
		else if (Global.pants == 3)
		{
			this.GetComponent<BodySpriteSwapper>().data = pants[3];
		}
		else
		{
			this.GetComponent<BodySpriteSwapper>().data = pants[4];
		}
	}
}
