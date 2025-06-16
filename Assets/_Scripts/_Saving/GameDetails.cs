using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Taken and adapted from http://amalgamatelabs.com/Blog/4/data_persistence


[System.Serializable]
public class GameDetails
{
    public int season;
    public int seeds;
    public int crops;
    public int gold;
    public int water;

    //New Crops
    public int seeds2;
    public int crops2;
    public int seeds3;
    public int crops3;


    //Data
    public int[] raindata;
    public int[,] yielddata;


    //Plots 
    public bool planted1;
    public bool planted2;

    //Player Settings
    public string username;
    public string password;

    public GameDetails()
    {
        /*
        season = Global.season;
        seeds = Global.seeds;
        crops = Global.crops;
        gold = Global.gold;
        water = Global.water;
        seeds2 = Global.seeds2;
        crops2 = Global.crops2;
        seeds3 = Global.seeds3;
        crops3 = Global.crops3;
        raindata = Global.raindata;
        yielddata = Global.yielddata;
        planted1 = Global.planted1;
        planted2 = Global.planted2;
        username = Global.username;
        password = Global.password;
        */       
    }
}
