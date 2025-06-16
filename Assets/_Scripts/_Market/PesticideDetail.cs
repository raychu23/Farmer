using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesticideDetail : MonoBehaviour
{
    public GameObject hovering;

    // Start is called before the first frame update
    void Start()
    {
        hovering.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnMouseOver()
    {
        hovering.SetActive(true);
    }
    private void OnMouseExit()
    {
        hovering.SetActive(false);
    }
}
