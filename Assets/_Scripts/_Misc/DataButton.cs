using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataButton : MonoBehaviour
{
    public void ShowData()
    {
        if(Global.season > 3)
        {
            gameObject.SetActive(true);
        }
    }
}
