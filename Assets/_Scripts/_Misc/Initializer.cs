using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{

    public string resource;

    // Start is called before the first frame update
    void Start()
    {
        if(resource.CompareTo("seed") == 0)
        {
            gameObject.GetComponent<Slot>().amount = Global.seeds;
        }
        else if(resource.CompareTo("crop") == 0)
        {
            gameObject.GetComponent<Slot>().amount = Global.crops;
        }
        else if (resource.CompareTo("water") == 0)
        {
            gameObject.GetComponent<Water>().amount = Global.water;
        }
    }

    void Update()
    {
        if (resource.CompareTo("seed") == 0)
        {
            gameObject.GetComponent<Slot>().amount = Global.seeds;
        }
        else if (resource.CompareTo("crop") == 0)
        {
            gameObject.GetComponent<Slot>().amount = Global.crops;
        }
        else if (resource.CompareTo("water") == 0)
        {
            gameObject.GetComponent<Water>().amount = Global.water;
        }
    }
}
