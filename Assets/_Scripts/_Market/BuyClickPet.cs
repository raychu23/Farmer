using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyClickPet : MonoBehaviour
{
    public GameObject errormessage;
    public GameObject pet;
    public static bool isbought = false;
    public Sound sound;

    // Start is called before the first frame update
    void Start()
    {
        errormessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Sale.currentclick = "pet";
        Debug.Log(Sale.currentclick);

        if (Global.gold < 30)
        {
            errormessage.SetActive(true);
        }
        else
        {
            sound.PlayCoinSound();
            Global.gold -= 30;
            Global.pet = true;
        }
    }
}
