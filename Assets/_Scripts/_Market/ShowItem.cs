using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItem : MonoBehaviour
{
    // tools
    public GameObject water;
    public GameObject fertilizer;
    public GameObject composter;
    public GameObject silo;
    public GameObject irrigation;
    public GameObject pesticide;
    // locks
    public GameObject lockblue;
    public GameObject lockred;
    // crops and seeds
    public GameObject crop1seedbuy;
    public GameObject crop2seedbuy;
    public GameObject crop3seedbuy;
    public GameObject crop1sale;
    public GameObject crop2sale;
    public GameObject crop3sale;
    // upgrades
    public GameObject hair;
    public GameObject shirt;
    public GameObject pants;

    /*
    // npcs
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject npc4;
    private Vector2 local1pos;
    private Vector2 local2pos;
    private Vector2 argpos;
    private Vector2 envpos;
    private float time;
    private float time2;
    */


    // Start is called before the first frame update
    void Start()
    {
        // tools
        water.SetActive(false);
        fertilizer.SetActive(false);
        composter.SetActive(false);
        irrigation.SetActive(false);
        silo.SetActive(false);
        pesticide.SetActive(false);

        // upgrades
        hair.SetActive(true);
        shirt.SetActive(false);
        pants.SetActive(false);

        // crops and seeds
        crop1seedbuy.SetActive(true);
        crop2seedbuy.SetActive(false);
        crop3seedbuy.SetActive(false);
        crop1sale.SetActive(true);
        crop2sale.SetActive(false);
        crop3sale.SetActive(false);

        // locks
        lockblue.SetActive(false);
        lockred.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        // tools
        if (Global.season > 3)
        {
            water.SetActive(true);
        }
        if (Global.season > 7)
        {
            silo.SetActive(true);
        }
        if (Global.season > 9)
        {
            fertilizer.SetActive(true);
        }
        if (Global.season > 10)
        {
            composter.SetActive(true);
        }

        if (Global.season > 14)
        {
            irrigation.SetActive(true);
        }
        
        if (Global.season > 19)
        {
            pesticide.SetActive(true);
        }

        // crops and seeds
        if (Global.season > 1)
        {
            crop1seedbuy.SetActive(true);
            crop1sale.SetActive(true);
        }
        if (Global.season > 5)
        {
            if (UnlockCrop.islock)
            {
                lockblue.SetActive(true);
                crop2seedbuy.SetActive(false);
                crop2sale.SetActive(false);
            }
            else
            {
                lockblue.SetActive(false);
                crop2seedbuy.SetActive(true);
                crop2sale.SetActive(true);
            }
        }
        if (Global.season > 8)
        {
            if (UnlockCrop2.islock2)
            {
                lockred.SetActive(true);
                crop3seedbuy.SetActive(false);
                crop3sale.SetActive(false);
            }
            else
            {
                lockred.SetActive(false);
                crop3seedbuy.SetActive(true);
                crop3sale.SetActive(true);
            }
        }


        // upgrades
        if (BuyCharacterClothes.buyhair)
        {
            hair.SetActive(false);

        }
        if (Global.season > 6)
        {
            if (BuyCharacterClothes.buyshirt)
            {
                shirt.SetActive(false);
            }
            else
            {
                shirt.SetActive(true);
            }
        }
        if (Global.season > 9)
        {
            if (BuyCharacterClothes.buypants)
            {
                pants.SetActive(false);
            }
            else
            {
                pants.SetActive(true);
            }
        }


        /*
        //npcs
        if (Global.season < 4)
        {
            npc1.SetActive(true);
        }//intro

        if (Global.season == 4 || Global.season == 5 || Global.season == 6)
        {
            npc1.SetActive(true);

        }//1 water amount

        if (Global.season == 7 || Global.season == 8)
        {
            npc2.SetActive(true);

        }//2 new crop


        if (Global.season == 8 || Global.season == 9)
        {
            npc3.SetActive(true);

        }//agr silo

         if (Global.season == 9 || Global.season == 10)
        {
            npc2.SetActive(true);

        }//agr nitrate

        if (Global.season == 11 || Global.season == 12 || Global.season == 13)
        {
            npc1.SetActive(true);

        }//1 fertilizer cost

        if (Global.season == 12 || Global.season == 13 || Global.season == 14 || Global.season == 15)
        {
            npc4.SetActive(true);

        }//env composter

        if (Global.season == 14 || Global.season == 15 || Global.season == 16)
        {
            npc3.SetActive(true);

        }//agr drought

        if (Global.season == 15 || Global.season == 16 || Global.season == 17)
        {
            npc2.SetActive(true);

        }//2 irr system

        if (Global.season == 17)
        {
            npc1.SetActive(true);

        }//1 price change
        if(Global.season > 19)
        {
            npc4.SetActive(true);
]
        }
    */
    }//Update()
}
