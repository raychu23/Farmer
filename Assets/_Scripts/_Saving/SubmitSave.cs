using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using TMPro;

//this script sends game data to the server
public class SubmitSave : MonoBehaviour
{
    public void SubmitUpload()
    {
        StartCoroutine(Upload());
    }


    public IEnumerator Upload()
    {
  
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

        using (UnityWebRequest www = UnityWebRequest.Post("https://stat2games.sites.grinnell.edu/php/savefarmergame.php", form))
        {

            yield return www.SendWebRequest();

            if(www.downloadHandler.text == "0")
            {
                Debug.Log("Saved!");
                StartCoroutine(SaveButton());
            }
            else
            {
                Debug.Log("Error: " + www.downloadHandler.text);
            }
        }

    }

    public IEnumerator SaveButton()
    {
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Saved!");
        yield return new WaitForSeconds(3);
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Save");

    }
}



