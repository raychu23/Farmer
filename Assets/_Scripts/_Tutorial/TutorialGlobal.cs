using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGlobal : MonoBehaviour
{
    //Starting Data
    public static int season = 1;
    public static int seeds = 500;
    public static int crops = 0;
    public static int gold = 500;
    public static int water = 500;
    public static int slotSelected = -1;

    //New Crops
    public static int seeds2 = 0;
    public static int crops2 = 0;
    public static int seeds3 = 0;
    public static int crops3 = 0;


    //Data
    public static int[] raindata = new int[30];
    public static int[,] yielddata = new int[30, 6];
    public static int[,] wateradded = new int[30, 6];
    public static int[,] croptype = new int[30, 6];
    public static string data = "";

    //Plot growth
    public static bool[] planted = new bool[6];
    public static bool[] harvest = { true, true, true, true, true, true };
    public static bool[] grown = new bool[6];
    public static bool rained = false;
    public static Models[] models = {new Models(), new Models(), new Models(), new Models(), new Models(),
                                     new Models(),};
    //Table
    public static bool renderRainData = false;
    public static bool renderYieldData = false;
    public static bool[,] plots = new bool[30,6];

    //Player Settings
    public static string username = "";
    public static string password = "";
    public static bool loggedIn = false;

    //Clothes
    public static int hair = 0;

    //Instructions
    public static int instructionNum = 0;

}
