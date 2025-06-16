using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUnlock : MonoBehaviour
{
    public GameObject composters;
    public GameObject irrigation;
    public GameObject silo;
    public GameObject pet;

    // Update is called once per frame
    void Update()
    {
        if (Global.composter)
        {
            composters.SetActive(true);
        }
        if (Global.irrigation)
        {
            irrigation.SetActive(true);
        }
        if (Global.silo)
        {
            silo.SetActive(true);
        }

        if (Global.pet)
        {
            pet.SetActive(true);
        }
    }
}
