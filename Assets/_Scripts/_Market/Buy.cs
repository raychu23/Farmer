using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buy : MonoBehaviour
{
    public GameObject selection;
    public Sound sound;
    void OnMouseDown()
    {
        sound.PlayButtonSound();
        selection.SetActive(true);
    }
}
