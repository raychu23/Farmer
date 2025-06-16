using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropColorClick : MonoBehaviour
{
    public void UpdateClicks()
    {
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            DataClicks.colorCrop++;
        }
    }
}
