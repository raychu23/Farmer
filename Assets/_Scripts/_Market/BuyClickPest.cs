using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyClickPest : MonoBehaviour
{
    // Start is called before the first frame update
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


    private void OnMouseDown()
    {
        Sale.currentclick = "pesticide";
        Debug.Log(Sale.currentclick);
    }
}
