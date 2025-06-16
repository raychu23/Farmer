using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSetter : MonoBehaviour
{
    public BodyData[] hair;


    // Update is called once per frame
    void Update()
    {
        if(Global.hair == 0)
        {
            this.GetComponent<BodySpriteSwapper>().data = hair[0];
        }
        else if (Global.hair == 1)
        {
            this.GetComponent<BodySpriteSwapper>().data = hair[1];
        }
		else if (Global.hair == 2)
		{
			this.GetComponent<BodySpriteSwapper>().data = hair[2];
		}
        else
        {
            this.GetComponent<BodySpriteSwapper>().data = hair[3];
        }
    }
}
