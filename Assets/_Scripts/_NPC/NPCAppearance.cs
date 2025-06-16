using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAppearance : MonoBehaviour
{
    public static bool[] sarahAppeared = new bool[4];
    public static bool[] johnAppeared = new bool[4];
    public static bool[] bobAppeared = new bool[4];
    public static bool[] hannahAppeared = new bool[4];

    //NPCs
    public GameObject sarah;
    public GameObject john;
    public GameObject bob;
    public GameObject hannah;


    void Start()
    {
        //Keep track of sarah
        NPCMessage sarahMessage = sarah.GetComponent<NPCMessage>();
        MessageTracker sarahTracker = sarah.GetComponent<MessageTracker>();
        if ((Global.season == 2 || Global.season == 3) && !sarahAppeared[0])
        {
            sarah.SetActive(true);
            sarahTracker.SetMessage(1);
            sarahAppeared[0] = true;
        }
        else if ((Global.season == 4 || Global.season == 5 || Global.season == 6) && !sarahAppeared[1])
        {
            sarah.SetActive(true);
            sarahTracker.SetMessage(2);
            sarahAppeared[1] = true;
        }
        else if ((Global.season == 8 || Global.season == 9 || Global.season == 10) && !sarahAppeared[2])
        {
            sarah.SetActive(true);
            sarahTracker.SetMessage(3);
            sarahAppeared[2] = true;
        }
        else if ((Global.season == 17 || Global.season == 18 || Global.season == 19) && !sarahAppeared[3])
        {
            sarah.SetActive(true);
            sarahTracker.SetMessage(4);
            sarahAppeared[3] = true;
        }

        //Keep track of John
        NPCMessage johnMessage = john.GetComponent<NPCMessage>();
        MessageTracker johnTracker = john.GetComponent<MessageTracker>();
        if ((Global.season == 5 || Global.season == 6) && !johnAppeared[0])
        {
            john.SetActive(true);
            johnTracker.SetMessage(1);
            johnAppeared[0] = true;
        }
        else if ((Global.season == 7 || Global.season == 8 || Global.season == 9) && !johnAppeared[1])
        {
            john.SetActive(true);
            johnTracker.SetMessage(2);
            johnAppeared[1] = true;
        }
        else if ((Global.season == 11 || Global.season == 12 || Global.season == 13) && !johnAppeared[2])
        {
            john.SetActive(true);
            johnTracker.SetMessage(3);
            johnAppeared[2] = true;
        }
        else if ((Global.season == 15 || Global.season == 16 || Global.season == 17) && !johnAppeared[3])
        {
            john.SetActive(true);
            johnTracker.SetMessage(4);
            johnAppeared[3] = true;
        }

        //Keep track of Bob
        NPCMessage bobMessage = bob.GetComponent<NPCMessage>();
        MessageTracker bobTracker = bob.GetComponent<MessageTracker>();
        if ((Global.season == 5 || Global.season == 6 || Global.season == 7) && !bobAppeared[0])
        {
            bob.SetActive(true);
            bobTracker.SetMessage(1);
            bobAppeared[0] = true;
        }
        else if ((Global.season == 10 || Global.season == 11 || Global.season == 12) && !bobAppeared[1])
        {
            bob.SetActive(true);
            bobTracker.SetMessage(2);
            bobAppeared[1] = true;
        }
        else if ((Global.season == 14 || Global.season == 15 || Global.season == 16) && !bobAppeared[2])
        {
            bob.SetActive(true);
            bobTracker.SetMessage(3);
            bobAppeared[2] = true;
        }

        //Keep track of Hannah
        NPCMessage hannahMessage = hannah.GetComponent<NPCMessage>();
        MessageTracker hannahTracker = hannah.GetComponent<MessageTracker>();
        if ((Global.season == 12 || Global.season == 13 || Global.season == 14) && !hannahAppeared[0])
        {
            hannah.SetActive(true);
            hannahTracker.SetMessage(1);
            hannahAppeared[0] = true;
        }
        else if ((Global.season == 21 || Global.season == 22 || Global.season == 23) && !hannahAppeared[1])
        {
            hannah.SetActive(true);
            hannahTracker.SetMessage(2);
            hannahAppeared[1] = true;
        }

    }
}


