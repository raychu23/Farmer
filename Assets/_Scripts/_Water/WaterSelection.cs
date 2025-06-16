using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public void AddWater()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
}
