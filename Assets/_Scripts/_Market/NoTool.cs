using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoTool : MonoBehaviour
{

    public GameObject info;
    private static bool displayed = false;

    // Start is called before the first frame update
    void Start()
    {
        info.SetActive(false);
    }

    void OnMouseDown()
    {
        if (!displayed)
        {
            GameObject.Find("Sound").GetComponent<Sound>().PlayButtonSound();
            if (Global.season < 4)
            {
                info.SetActive(true);
            }
            else
            {
                info.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText
                    ("This is the Tool Stall. You can buy all kinds of tools for your farm. More items are coming up and some of them are refundable.");
                info.SetActive(true);
            }
            displayed = true;
        } else
        {
            info.SetActive(false);
        }
    }
}
