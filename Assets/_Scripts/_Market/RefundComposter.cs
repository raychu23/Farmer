using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefundComposter : MonoBehaviour
{
    public static bool comrefund = false;
    public GameObject com;
    public GameObject refundcom;
    public GameObject table;
    public Sound sound;

    // Start is called before the first frame update
    void Start()
    {
        com.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (comrefund)
        {
            com.SetActive(true);
            refundcom.SetActive(false);
        }

    }

    void OnMouseDown()
    {
        sound.PlayCoinSound();
        comrefund = true;
        Global.gold += 800;
        Global.composter = false;
        BuyClickComposter.isbought = false;
        table.SetActive(false);
    }
}
