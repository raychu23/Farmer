using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsButton : MonoBehaviour
{
    public GameObject questButton;

    // Update is called once per frame
    void Update()
    {
        if(Global.season >= 2)
        {
            questButton.SetActive(true);
        }
    }
}
