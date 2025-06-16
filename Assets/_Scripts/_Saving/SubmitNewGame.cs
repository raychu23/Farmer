
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

//this script sends game data to the server
public class SubmitNewGame : MonoBehaviour
{

    public GameObject errorMessage;

    public void SubmitUpload()
    {
        StartCoroutine(Upload());
    }

    public IEnumerator Upload()
    {
        ResetVars();
        WWWForm form = new WWWForm();
        form.AddField("PlayerID", Global.username);
        form.AddField("GroupID", Global.password);
        form.AddField("Season", Global.season);
        form.AddField("Gold", Global.gold);
        form.AddField("CornSeeds", Global.seeds);
        form.AddField("CornCrop", Global.crops);
        form.AddField("BeanSeeds", Global.seeds2);
        form.AddField("BeanCrop", Global.crops2);
        form.AddField("CarrotSeeds", Global.seeds3);
        form.AddField("CarrotCrop", Global.crops3);
        form.AddField("Water", Global.water);
        form.AddField("Fertilizer", Global.fertilizer);
        form.AddField("Composter", Global.composter.ToString());
        form.AddField("Irrigation", Global.irrigation.ToString());
        form.AddField("Silo", Global.silo.ToString());
        form.AddField("Hair", Global.hair);
        form.AddField("Shirt", Global.shirt);
        form.AddField("Pants", Global.pants);

        using (UnityWebRequest www = UnityWebRequest.Post("https://stat2games.sites.grinnell.edu/php/newfarmergame.php", form))
        {

            yield return www.SendWebRequest();

            if (www.downloadHandler.text == "0")
            {
                Debug.Log("User added");
                //Global.loadCore = true;
                SceneManager.LoadScene("Level_Farm");
            }
            else
            {
                errorMessage.SetActive(true);
            }
        }

    }

    private void ResetVars()
    {
        //Starting Data
        Global.season = 1;
        Global.seeds = 6;
        Global.crops = 0;
        Global.gold = 100;
        Global.slotSelected = -1;
        Global.loadCore = false;
        Global.muted = false;

        //New Crops
        Global.seeds2 = 0;
        Global.crops2 = 0;
        Global.seeds3 = 0;
        Global.crops3 = 0;

        //Upgrades
        Global.water = 100;
        Global.fertilizer = 3;
        Global.composter = false;
        Global.irrigation = false;
        Global.silo = false;
        Global.pesticides = 3;

        //Data
        Global.raindata = new float[30];
        Global.yielddata = new float[30, 6];
        Global.wateradded = new int[30, 6];
        Global.croptype = new int[30, 6];
        Global.nitrate = new float[30, 6];
        Global.data = "";
        Global.rain = 0;
        Global.lastSeasonRendered = 1;

        //Prices storage
        Global.cornSeed = new int[30];
        Global.beanSeed = new int[30];
        Global.carrotSeed = new int[30];
        Global.cornCrop = new int[30];
        Global.beanCrop = new int[30];
        Global.carrotCrop = new int[30];

        //Current prices
        Global.currCornSeed = 10;
        Global.currBeanSeed = 6;
        Global.currCarrotSeed = 10;
        Global.currCornCrop = 5;
        Global.currBeanCrop = 10;
        Global.currCarrotCrop = 20;

        //Table
        Global.renderRainData = false;
        Global.renderYieldData = false;
        Global.plots = new bool[30, 6];

        //Plot growth
        Global.planted = new bool[6];
        Global.harvest = new bool[6]; 
        for(int i = 0; i < 6; i++)
        {
            Global.harvest[i] = true;
        }
        Global.grown = new bool[6];
        Global.rained = false;
        Global.models = new Models[6]; 
        for(int i = 0; i < 6; i++)
        {
            Global.models[i] = new Models();
        }
        Global.nitrateUpdated = new bool[6];

        //Player Settings
        Global.loggedIn = false;
        Global.tutorial = false;

        //Clothes
        Global.hair = 0;
        Global.shirt = 0;
        Global.pants = 0;

        //Misc
        Global.fertUsed = 0;
        Global.pestUsed = new bool[30, 6];
        Global.pests = new bool[30, 6];

        //Quests

        //False if inactive or not claimed, true if claimed
        Global.quests = new bool[9];
        Global.newQuest = false;
        Global.canClaim = new bool[9];
        Global.fertCounter = 0;
        Global.waterCounter = 0;
        Global.winAlert = false;

        NPCAppearance.sarahAppeared = new bool[4];
        NPCAppearance.johnAppeared = new bool[4];
        NPCAppearance.bobAppeared = new bool[4];
        NPCAppearance.hannahAppeared = new bool[4];
    }


}



