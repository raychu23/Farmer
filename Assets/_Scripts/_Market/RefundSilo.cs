using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefundSilo : MonoBehaviour
{
    public static bool refund = false;
    public GameObject silo;
    public GameObject refundsilo;
    public GameObject table;
    public Sound sound;

    // Start is called before the first frame update
    void Start()
    {
        silo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (refund)
        {
            silo.SetActive(true);
            refundsilo.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        sound.PlayCoinSound();
        refund = true;
        Global.gold += 400;
        Global.silo = false;
        BuyClickSilo.isbought = false;
        table.SetActive(false);
    }


}
