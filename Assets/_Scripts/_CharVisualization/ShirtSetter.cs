using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtSetter : MonoBehaviour
{
    public BodyData[] shirt;


	// Update is called once per frame
	void Update()
	{
		if (Global.shirt == 0)
		{
			this.GetComponent<BodySpriteSwapper>().data = shirt[0];
		}
		else if (Global.shirt == 1)
		{
			this.GetComponent<BodySpriteSwapper>().data = shirt[1];
		}
		else if (Global.shirt == 2)
		{
			this.GetComponent<BodySpriteSwapper>().data = shirt[2];
		}
		else if (Global.shirt == 3)
		{
			this.GetComponent<BodySpriteSwapper>().data = shirt[3];
		}
		else
		{
			this.GetComponent<BodySpriteSwapper>().data = shirt[4];
		}
	}
}
