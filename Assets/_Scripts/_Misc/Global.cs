using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    //Starting Data
    public static int season = 1;
    public static int seeds = 6;
    public static int crops = 0;
    public static int gold = 100;
    public static int slotSelected = -1;
    public static bool loadCore = false;
    public static bool muted = false;

    //New Crops
    public static int seeds2 = 0;
    public static int crops2 = 0;
    public static int seeds3 = 0;
    public static int crops3 = 0;

    //Upgrades
    public static int water = 100;
    public static int fertilizer = 3;
    public static bool composter = false;
	public static bool irrigation = false;
    public static bool silo = false;
    public static int pesticides = 3;
    public static bool pet = false;

    //Data
    public static float[] raindata = new float[30];
    public static float[,] yielddata = new float[30, 6];
    public static int[,] wateradded = new int[30, 6];
    public static int[,] croptype = new int[30, 6];
    public static float[,] nitrate = new float[30, 6];
    public static string data = "";
    public static int rain = 0;
    public static int lastSeasonRendered = 1;

    //Prices storage
    public static int[] cornSeed = new int[30];
    public static int[] beanSeed = new int [30];
    public static int[] carrotSeed = new int [30];
    public static int[] cornCrop = new int[30];
    public static int[] beanCrop = new int[30];
    public static int[] carrotCrop = new int[30];

    //Current prices
    public static int currCornSeed = 10;
    public static int currBeanSeed = 6;
    public static int currCarrotSeed = 10;
    public static int currCornCrop = 5;
    public static int currBeanCrop = 10;
    public static int currCarrotCrop = 20;

    //Table
    public static bool renderRainData = false;
    public static bool renderYieldData = false;
    public static bool[,] plots = new bool[30, 6];

    //Plot growth
    public static bool[] planted = new bool[6];
    public static bool[] harvest = { true, true, true, true, true, true };
    public static bool[] grown = new bool[6];
    public static bool rained = false;
    public static Models[] models = {new Models(), new Models(), new Models(), new Models(), new Models(),
                                     new Models(),};
    public static bool[] nitrateUpdated = new bool[6];

    //Player Settings
    public static string username = "";
    public static string password = "";
    public static bool loggedIn = false;
    public static bool tutorial = false;

	//Clothes
	public static int hair = 0;
    public static int shirt = 1;
	public static int pants = 1;

    //Misc
    public static int fertUsed = 0;
    public static bool[,] pestUsed = new bool[30,6];
    public static bool[,] pests = new bool[30, 6];

    //Quests
    public static bool winAlert = false;

    //False if inactive or not claimed, true if claimed
    public static bool[] quests = new bool[9];
    public static bool newQuest = false;
    public static bool[] canClaim = new bool[9];
    public static int fertCounter = 0;
    public static int waterCounter = 0;
}
