using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    public QuestDisplay display;
    public GameObject alertIcon;
    public GameObject winAlert;

    // Update is called once per frame
    private void Update()
    {
        //Display claim alert if there are quests to claim
        bool canClaim = false;
        foreach(bool claim in Global.canClaim)
        {
            if (claim)
            {
                canClaim = true;
                Debug.Log("found claim");
                break;
            }
        }

        if (canClaim)
        {
            alertIcon.SetActive(true);
        }
        else
        {
            alertIcon.SetActive(false);
        }


        //Check if all quests are completed
        if (Global.season >= 20 && !Global.winAlert)
        {
            bool allWon = true;
            for (int i = 0; i < 9; i++)
            {
                if (!Global.quests[i])
                {
                    allWon = false;
                    break;
                }
            }

            if (allWon)
            {
                winAlert.SetActive(true);
                Global.winAlert = true;
            }
        }
    }



    public void CheckQuests()
    {

        if (Global.season >= 2)
        {
            //Quest 1: Procure 200 bushels of corn in less than 2 seasons
            if (!Global.quests[0])
            {
                int corn = 0;

                //Counts corn crop in last 2 seasons
                for(int i = 0; i < 6; i++)
                {
                    if(Global.croptype[Global.season-1, i] == 1)
                    {
                        corn += Mathf.RoundToInt(Global.yielddata[Global.season - 1, i]);

                    }
                    if (Global.croptype[Global.season - 2, i] == 1)
                    {
                        corn += Mathf.RoundToInt(Global.yielddata[Global.season - 2, i]);

                    }
                }

                //If more than 200 claim quest
                if(corn >= 200)
                {
                    Global.canClaim[0] = true;
                    display.SetQuestNum(2);
                }
            }
        }
        if (Global.season >= 4)
        {
            //Quest 2: 3 distinct total waters
            if (!Global.quests[1])
            {
                int[] distinct = new int[6];

                //Counts how many are distinct so far
                int counter = 0;

                for (int i = 0; i < 6; i++)
                {
                    if (Global.croptype[Global.season - 1, i] != 0)
                    {
                        int water = (int)(Global.raindata[Global.season - 1] + Global.wateradded[Global.season - 1, i]);

                        //Check if this plot is distinct from all 
                        bool allDistinct = true;

                        for (int j = 0; j < counter; j++)
                        {
                            if (distinct[j] == water)
                            {
                                allDistinct = false;
                                break;
                            }
                        }

                        //Add to array if distinct from all recorded
                        if (allDistinct)
                        {
                            distinct[counter] = water;
                            counter++;
                        }
                    }
                }
                if (counter >= 3)
                {
                    Global.canClaim[1] = true;
                    display.SetQuestNum(4);
                }
            }
        }

        //Quest 3: All 6 plots produce at least 18 corn
        if(Global.season >= 6)
        {
            if (!Global.quests[2])
            {
                bool allEnough = true;
                for(int i = 0; i < 6; i++)
                {
                    if ((Global.croptype[Global.season-1, i] != 1) || (Global.yielddata[Global.season-1, i] < 17))
                    {
                        allEnough = false;
                        break;
                    }
                }

                if (allEnough)
                {
                    Global.canClaim[2] = true;
                    display.SetQuestNum(6);
                }
            }
        }

        //Quest 4: harvest 50 corn and 50 bean
        if(Global.season >= 8)
        {
            if (!Global.quests[3])
            {
                int corn = 0;
                int bean = 0;

                for(int i = 8; i<=Global.season; i++)
                {
                    for(int j = 0; j<6; j++)
                    {
                        if (Global.croptype[i - 1, j] == 1)
                        {
                            corn +=  Mathf.RoundToInt(Global.yielddata[i - 1, j]);
                        }
                        else if (Global.croptype[i - 1, j] == 2)
                        {
                            bean += Mathf.RoundToInt(Global.yielddata[i - 1, j]);
                        }
                    }
                }
                if(corn >= 50 && bean >= 50)
                {
                    Global.canClaim[3] = true;
                    display.SetQuestNum(8);

                }
            }
        }

        //Quest 5: Harvest 30 corn, 30 beans, and 30 carrots
        if(Global.season >= 10)
        {
            if (!Global.quests[4])
            {
                int corn = 0;
                int bean = 0;
                int carrot = 0;

                for (int i = 8; i <= Global.season; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (Global.croptype[i - 1, j] == 1)
                        {
                            corn += Mathf.RoundToInt(Global.yielddata[i - 1, j]);
                        }
                        else if (Global.croptype[i - 1, j] == 2)
                        {
                            bean += Mathf.RoundToInt(Global.yielddata[i - 1, j]);
                        }
                        else if(Global.croptype[i-1,j] == 3)
                        {
                            carrot += Mathf.RoundToInt(Global.yielddata[i - 1, j]);
                        }
                    }
                }

                if (corn >= 30 && bean >= 30 && carrot >= 30)
                {
                    Global.canClaim[4] = true;
                    display.SetQuestNum(10);


                }
            }
        }

        //Quest 6: Use 10 fertilizer
        if(Global.season >= 12)
        {
            if (!Global.quests[5])
            {
                Global.fertCounter += Global.fertUsed;
                if(Global.fertCounter >= 10)
                {
                    Global.canClaim[5] = true;
                    display.SetQuestNum(12);


                }
            }
        }

        //Quest 7: Buy 100 water
        if (Global.season >= 14)
        {
            if (!Global.quests[6])
            {
                if(Global.waterCounter >= 100)
                {
                    Global.canClaim[6] = true;
                    display.SetQuestNum(14);

                }
            }
        }

        //Quest 8: Have at least 75 beans in your inventory 
        if (Global.season >= 17)
        {
            if (!Global.quests[7])
            {
                if(Global.crops2 >= 75)
                {
                    Global.canClaim[7] = true;
                    display.SetQuestNum(17);
                }
            }
        }

        //Quest 9: add pesticide to all 6 plots in one season
        if(Global.season >= 20)
        {

            if (!Global.quests[8])
            {
                bool allPesticides = true;

                for(int i = 0; i < 6; i++)
                {
                    if(!Global.pestUsed[Global.season-1, i])
                    {
                        allPesticides = false;
                        break;
                    }
                }

                if (allPesticides)
                {
                    Global.canClaim[8] = true;
                    display.SetQuestNum(19);
                }
            }
        }

    }
}
