using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject saveButton;
    public GameObject menuButton;
    // Start is called before the first frame update
    void Start()
    {
        if(Global.season != 1)
        {
            saveButton.SetActive(true);
            menuButton.SetActive(true);
        }
    }
            
}
