using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataEnableTut : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (TutorialGlobal.instructionNum != 9)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
