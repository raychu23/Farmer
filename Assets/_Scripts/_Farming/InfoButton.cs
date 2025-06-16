using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoButton : MonoBehaviour
{
    public int plotNum;
    public GameObject displayer;
    public Sound buttonSound;

    private void OnMouseDown()
    {
        buttonSound.PlayButtonSound();
        if (!EventSystem.current.IsPointerOverGameObject())
        {
                displayer.SetActive(true);
            displayer.GetComponent<InfoDisplayer>().SetText(plotNum);
        }
    }
}
