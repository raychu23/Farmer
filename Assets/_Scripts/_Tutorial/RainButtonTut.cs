using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainButtonTut : MonoBehaviour
{
    public GameObject rain;
    public GameObject growButton;

    public void StartRain()
    {
        rain.GetComponent<RainTut>().GetRain();
        TutorialGlobal.rained = true;

        if (TutorialGlobal.instructionNum >= 5)
        {
            growButton.SetActive(true);
        }
        TutorialGlobal.renderRainData = true;
        Debug.Log("set render rain data to true");
        this.gameObject.SetActive(false);

    }
}
