using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloset : MonoBehaviour
{
    public GameObject door;
    public GameObject opendoor;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(true);
        opendoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (count % 2 == 1)
        {
            door.SetActive(false);
            opendoor.SetActive(true);
        } else if (count % 2 == 0)
        {
            door.SetActive(true);
            opendoor.SetActive(false);
        } 
    }

    private void OnMouseDown()
    {
        count++;
    }
}
