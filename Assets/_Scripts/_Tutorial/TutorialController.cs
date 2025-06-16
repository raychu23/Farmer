using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public TutInstructions insObj;
    public GameObject startButton;
    public GameObject nextButton;
    public SlotTut seedSlot;
    public GameObject goldCircle;
    public GameObject dataCircle;
    public GameObject rainCircle;
    public GameObject exitCircle;
    public GameObject sign1;
    public GameObject sign2;
    public GameObject sign3;
    public GameObject sign4;
    public GameObject sign5;
    public GameObject sign6;



    //----------Instructions-----------------
    //Reset all variables every time the tutorial loads
    private void Start()
    {
        TutorialGlobal.season = 1;
        TutorialGlobal.seeds = 500;
        TutorialGlobal.crops = 0;
        TutorialGlobal.gold = 500;
        TutorialGlobal.water = 500;
        TutorialGlobal.slotSelected = -1;
        TutorialGlobal.raindata = new int[30];
        TutorialGlobal.yielddata = new int[30, 6];
        TutorialGlobal.wateradded = new int[30, 6];
        TutorialGlobal.croptype = new int[30, 6];
        TutorialGlobal.data = "";

        //Plot growth
        TutorialGlobal.planted = new bool[6];
        TutorialGlobal.harvest = new bool[6];
        TutorialGlobal.grown = new bool[6];
        TutorialGlobal.rained = false;
        TutorialGlobal.models = new Models[6];

        for(int i = 0; i < 6; i++)
        {
            TutorialGlobal.harvest[i] = true;
            TutorialGlobal.models[i] = new Models();
        }
        //Table
        TutorialGlobal.renderRainData = false;
        TutorialGlobal.renderYieldData = false;
        TutorialGlobal.plots = new bool[30, 6];

        //Player Settings
        TutorialGlobal.username = "";
        TutorialGlobal.password = "";
        TutorialGlobal.loggedIn = false;

        //Clothes
        TutorialGlobal.hair = 0;

        //Instructions
        TutorialGlobal.instructionNum = 0;
    }



    private void Update()
    {
        switch (TutorialGlobal.instructionNum)
        {
            //Arrow keys
            case 0:
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)
                    || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
                    || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) 
                    || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    this.UpdateNum();
                }
                break;
            //Case 1: selecting seed slot (in slot script)
            //Case 2: selecting plots (farm tut script)
            //Case 3: raining (rain tut script)
            //Case 4: harvesting
            //Case 5: market
            //Case 6: drought
            case 1:
                seedSlot.transform.GetChild(5).gameObject.SetActive(true);
                break;
            case 2:
                seedSlot.transform.GetChild(5).gameObject.SetActive(false);
                break;
            case 9:
                dataCircle.SetActive(true);
                break;
            case 10:
                dataCircle.SetActive(false);
                break;
            case 11:
                nextButton.SetActive(true);
                goldCircle.SetActive(true);
                break;
            case 12:
                goldCircle.SetActive(false);
                rainCircle.SetActive(true);
                break;
            case 13:
                rainCircle.SetActive(false);
                break;
            case 14:
                sign1.SetActive(true);
                sign2.SetActive(true);
                sign3.SetActive(true);
                sign4.SetActive(true);
                sign5.SetActive(true);
                sign6.SetActive(true);
                break;
            case 15:
                sign1.SetActive(false);
                sign2.SetActive(false);
                sign3.SetActive(false);
                sign4.SetActive(false);
                sign5.SetActive(false);
                sign6.SetActive(false);
                nextButton.SetActive(false);
                startButton.SetActive(true);
                exitCircle.SetActive(true);
                break;
        }
    }




    //----------Helper methods---------------

    public void UpdateNum()
    {
        TutorialGlobal.instructionNum++;
        insObj.UpdateInstructions();
    }
}
