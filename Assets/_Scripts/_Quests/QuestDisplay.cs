using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public TextMeshProUGUI rewardText;
    public TextMeshProUGUI currentQuestNum;
    public Button rightArrow;
    public Button leftArrow;
    public Button claimButton;
    public string[] quests;
    public string[] rewards;
    

    private int questNum;
    private int maxNum;

    // Start is called before the first frame update
    void Start()
    {

        //Can't go forward depending on what season you're on
        maxNum = 0;
        if(Global.season < 4)
        {
            maxNum = 0;
        }
        else if (Global.season < 6)
        {
            maxNum = 1;
        }
        else if (Global.season < 8)
        {
            maxNum = 2;
        }
        else if (Global.season < 10)
        {
            maxNum = 3;
        }
        else if (Global.season < 12)
        {
            maxNum = 4;
        }
        else if (Global.season < 14)
        {
            maxNum = 5;
        }
        else if (Global.season < 17)
        {
            maxNum = 6;
        }
        else if (Global.season < 20)
        {
            maxNum = 7;
        }
        else
        {
            maxNum = 8;
        }


        //If all quests completed, just start at first screen
        if (Global.season >= 2)
        {
            SetTexts(0);
            //Start quest display with last quest
            for (int i = maxNum; i >= 0; i--)
            {
                if (!Global.quests[i])
                {
                    SetTexts(i);
                    break;
                }
            }
        }
    }


    private void Update()
    {
        //Can't go forward depending on what season you're on
        maxNum = 0;

        if(Global.season < 4)
        {
            maxNum = 0;
            Debug.Log("max num is 0");
        }
        else if (Global.season < 6)
        {
            maxNum = 1;
            Debug.Log("max num is 1");
        }
        else if (Global.season < 8)
        {
            maxNum = 2;
        }
        else if (Global.season < 10)
        {
            maxNum = 3;
        }
        else if (Global.season < 12)
        {
            maxNum = 4;
        }
        else if (Global.season < 14)
        {
            maxNum = 5;
        }
        else if (Global.season < 17)
        {
            maxNum = 6;
        }
        else if (Global.season < 20)
        {
            maxNum = 7;
        }
        else
        {
            maxNum = 8;
        }

        //Check if quest is claimable
        SetTexts(questNum);

        //Can't go back if you're on the first quest
        if (questNum == 0)
        {
            leftArrow.interactable = false;
        }
        else
        {
            leftArrow.interactable = true;
        }
        Debug.Log(questNum);
        Debug.Log(maxNum);


        //Can't go forward depending on what season you're on
        if(questNum >= maxNum)
        {
            rightArrow.interactable = false;
        }
        else
        {
            rightArrow.interactable = true;
        }
    }

    public void SetQuestNum(int season)
    {
        if(season < 2)
        {          
            claimButton.interactable = false;
        }
        else if (season < 4)
        {
            maxNum = 0;
            SetTexts(maxNum);
            claimButton.interactable = false;
        }
        else if(season < 6)
        {
            maxNum = 1;
            SetTexts(maxNum);
            claimButton.interactable = false;
        }
        else if (season < 8)
        {
            maxNum = 2;
            SetTexts(maxNum);
        }
        else if(season < 10)
        {
            maxNum = 3;
            SetTexts(maxNum);
        }
        else if (season < 12)
        {
            maxNum = 4;
            SetTexts(maxNum);
        }
        else if (season < 14)
        {
            maxNum = 5;
            SetTexts(maxNum);
        }
        else if (season < 17)
        {
            maxNum = 6;
            SetTexts(maxNum);
        }
        else if (season < 20)
        {
            maxNum = 7;
            SetTexts(maxNum);
        }
        else
        {
            maxNum = 8;
            SetTexts(maxNum);
        }
        // newText.SetActive(true);
    }

    public void Next()
    {
        questNum++;
        SetTexts(questNum);
    }

    public void Back()
    {
        questNum--;
        SetTexts(questNum);
     //  newText.SetActive(false);
    }

    private void SetTexts(int num)
    {
        questNum = num;
        currentQuestNum.SetText((questNum + 1).ToString());
        questText.SetText(quests[num]);
        rewardText.SetText(rewards[num]);
        Debug.Log(Global.quests[num]);
        if (Global.quests[num])
        {
            claimButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Claimed!");
            claimButton.interactable = false;
        }
        else if (!Global.canClaim[num])
        {
            claimButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Claim");
            claimButton.interactable = false;
        }
        else
        {
            claimButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Claim");
            claimButton.interactable = true;
        }
    }

    public int GetMaxNum()
    {
        return this.maxNum;
    }

    public void Claim()
    {
        Global.quests[questNum] = true;
        Global.canClaim[questNum] = false;
        Global.gold += int.Parse(rewards[questNum]);
        claimButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Claimed!");
        claimButton.interactable = false;
    }
}
