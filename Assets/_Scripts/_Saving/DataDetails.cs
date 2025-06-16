using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.InteropServices;
using System;

//Taken and adapted from http://amalgamatelabs.com/Blog/4/data_persistence


public class DataDetails : MonoBehaviour
{
    /*
    [DllImport("__Internal")]
    private static extern void SyncFiles();

    [DllImport("__Internal")]
    private static extern void WindowAlert(string message);

    public static void Save()
    {
        GameDetails data = new GameDetails();
        string dataPath = string.Format("{0}/GameDetails.dat", Application.persistentDataPath);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream;

        try
        {
            if (File.Exists(dataPath))
            {
                File.WriteAllText(dataPath, string.Empty);
                fileStream = File.Open(dataPath, FileMode.Open);
            }
            else
            {
                fileStream = File.Create(dataPath);
            }

            binaryFormatter.Serialize(fileStream, data);
            fileStream.Close();

            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                Debug.Log("syncing files");
                SyncFiles();
            }
        }
        catch (Exception e)
        {
            PlatformSafeMessage("Failed to Save: " + e.Message);
        }
    }

    public static void Load()
    {
        GameDetails data = null;
        string dataPath = string.Format("{0}/GameDetails.dat", Application.persistentDataPath);

        try
        {
            if (File.Exists(dataPath))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = File.Open(dataPath, FileMode.Open);

                data = (GameDetails)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }
        }
        catch (Exception e)
        {
            PlatformSafeMessage("Failed to Load: " + e.Message);
        }

        if(data != null)
        {
            Global.season = data.season;
            Global.seeds = data.seeds;
            Global.crops = data.crops;
            Global.gold = data.gold;
            Global.water = data.water;
            Global.seeds2 = data.seeds2;
            Global.crops2 = data.crops2;
            Global.seeds3 = data.seeds3;
            Global.crops3 = data.crops3;
            Global.raindata = data.raindata;
            Global.yielddata = data.yielddata;
            Global.planted1 = data.planted1;
            Global.planted2 = data.planted2;
            Global.username = data.username;
            Global.password = data.password;
        }
       
    }

    private static void PlatformSafeMessage(string message)
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            WindowAlert(message);
        }
        else
        {
            Debug.Log(message);
        }
    }
    */
}
