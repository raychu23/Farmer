using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefundIrrigation : MonoBehaviour
{
    public static bool irrirefund = false;
    public GameObject irr;
    public GameObject refundirr;
    public GameObject table;
    public Sound sound;

    // Start is called before the first frame update
    void Start()
    {
        irr.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (irrirefund)
        {
            irr.SetActive(true);
            refundirr.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        sound.PlayCoinSound();
        irrirefund = true;
        Global.gold += 2000;
        Global.irrigation = false;
        BuyClickIrrigation.isbought = false;
        table.SetActive(false);
    }
}
