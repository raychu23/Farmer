using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderFine : MonoBehaviour
{
    public void Fine()
    {
        if(Global.gold > 1500)
        {
            Global.gold -= 1500;
        }
        else
        {
            Global.gold = 0;
        }
    }
}
