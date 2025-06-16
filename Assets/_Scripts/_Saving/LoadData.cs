using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    public GameObject noUserError;

    private string data;
    // Start is called before the first frame update
    public void SubmitData()
    {
        data = "";
        StartCoroutine(GetData());
    }

    // Update is called once per frame
    public IEnumerator GetData()
    {

        WWWForm form = new WWWForm();
        form.AddField("PlayerID", Global.username);
        form.AddField("GroupID", Global.password);


        using (UnityWebRequest www = UnityWebRequest.Post("https://stat2games.sites.grinnell.edu/php/getfarmerdata.php", form))
        {

            yield return www.SendWebRequest();
            data = www.downloadHandler.text;
        }

        Debug.Log(data);
        string[] dataVals = data.Split(',');

        if(data == "1")
        {
            Debug.Log("No entries");
            noUserError.SetActive(true);
        }
        else
        {
            Global.season = int.Parse(dataVals[2]);
            Global.gold = int.Parse(dataVals[3]);
            Global.seeds = int.Parse(dataVals[4]);
            Global.crops = int.Parse(dataVals[5]);
            Global.seeds2 = int.Parse(dataVals[6]);
            Global.crops2 = int.Parse(dataVals[7]);
            Global.seeds3 = int.Parse(dataVals[8]);
            Global.crops3 = int.Parse(dataVals[9]);
            Global.water = int.Parse(dataVals[10]);
            Global.fertilizer = int.Parse(dataVals[11]);

            Global.composter = int.Parse(dataVals[12]) == 1;
            Global.irrigation = int.Parse(dataVals[13]) == 1;
            Global.silo = int.Parse(dataVals[14]) == 1;
            Global.hair = int.Parse(dataVals[15]);
            Global.shirt = int.Parse(dataVals[16]);
            Global.pants = int.Parse(dataVals[17]);

            Global.loadCore = true;
            SceneManager.LoadScene("Level_Farm");
        }

    }
}
