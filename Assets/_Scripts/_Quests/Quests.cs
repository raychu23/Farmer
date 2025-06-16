using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public GameObject alertImage;
    public QuestDisplay display;


    private void Start()
    {
        if (Global.newQuest)
        {
            alertImage.SetActive(true);
        }
    }

    public void UpdateQuest()
    {
        if(Global.season == 2 || Global.season == 4 || Global.season == 6 || Global.season == 8 || Global.season == 10
           || Global.season == 12 || Global.season == 14 || Global.season == 17 || Global.season == 20)
        {
            alertImage.SetActive(true);
            display.SetQuestNum(Global.season);
            Global.newQuest = true;
        }
    }


    public void SeenQuest()
    {
        Global.newQuest = false;
    }
}
