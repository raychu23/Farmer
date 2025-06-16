using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


//Taken and adapted from
public class DataAccess
{
    [DllImport("__Internal")]
    private static extern void SyncFiles();

    [DllImport("__Internal")]
    private static extern void WindowAlert(string message);

    public static void Save(GameDetails gameDetails)
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/GameDetails.dat", FileMode.OpenOrCreate);
        bf.Serialize(file, gameDetails);
        file.Close();
        SyncFiles();

        /*
        string dataPath = Application.persistentDataPath + "/GameDetails.dat");
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream filestream = File.Open(dataPath, FileMode.OpenOrCreate); 
       
        binaryFormatter.Serialize(fileStream, gameDetails);
        fileStream.Close();

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            SyncFiles();
        }
        */

    }

    public static GameDetails Load()
    {
        if (File.Exists(Application.persistentDataPath + "/GameDetails.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameDetails.dat", FileMode.Open);
            GameDetails details =  (GameDetails)bf.Deserialize(file);
            file.Close();
            return details;
        }
        else
        {
            return null;
        }
    }
    /*
    GameDetails gameDetails = null;
    string dataPath = string.Format("{0}/GameDetails.dat", Application.persistentDataPath);
    if (File.Exists(dataPath))
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(dataPath, FileMode.Open);

        gameDetails = (GameDetails)binaryFormatter.Deserialize(fileStream);
        fileStream.Close();
    }
    return gameDetails;
}
*/
}
/*
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


