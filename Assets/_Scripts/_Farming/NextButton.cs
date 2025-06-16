using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public TutorialController controller;
   
    public void UpdateInst()
    {
        controller.UpdateNum();
    }
}
