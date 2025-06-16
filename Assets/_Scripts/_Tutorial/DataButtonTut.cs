using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataButtonTut : MonoBehaviour
{
    public GameObject startButton;

    public void UpdateTut()
    {
        if (TutorialGlobal.instructionNum == 9) 
        {
            GameObject.Find("GameController").GetComponent<TutorialController>().UpdateNum();
        }
        else if(TutorialGlobal.instructionNum == 15)
        {
            GameObject.Find("GameController").GetComponent<TutorialController>().UpdateNum();
            startButton.SetActive(true);
        }
    }
}
