using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnableButton : MonoBehaviour
{
    public TMP_InputField groupID;
    public TMP_InputField playerID;

    // Start is called before the first frame update
    void Start()
    {
        if (Global.tutorial)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerID.text != "" && groupID.text != "")
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
