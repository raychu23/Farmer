using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

//this script sends game data to the server
public class SubmitData : MonoBehaviour
{


    public void SubmitUpload()
    {
        StartCoroutine(Upload());
    }

    public IEnumerator Upload()
    {

        int gameNum = -1;

        WWWForm numForm = new WWWForm();
        numForm.AddField("PlayerID", Global.username);
        numForm.AddField("GroupID", Global.password);

        //Fetch game number
        using (UnityWebRequest www = UnityWebRequest.Post("https://stat2games.sites.grinnell.edu/php/getfarmgamenum.php", numForm))
        {
            yield return www.SendWebRequest();
            try
            {
                gameNum = int.Parse(www.downloadHandler.text);
            }
            catch (Exception e)
            {
                Debug.Log("Fetching game number failed.  Error message: " + e.ToString());
            }
        }


        //Send individual plot data
        for (int i = 0; i < 6; i++)
        {
            if (Global.croptype[Global.season - 2, i] != 0)
            {
                WWWForm form = new WWWForm();
                form.AddField("GameNum", gameNum);
                form.AddField("PlayerID", Global.username);
                form.AddField("GroupID", Global.password);
                form.AddField("Season", Global.season - 1);
                form.AddField("Money", Global.gold);
                form.AddField("Plot", i + 1);

                //Adding crop type 
                //Note: use Global.season - 2 b/c array index starts at 0
                if (Global.croptype[Global.season - 2, i] == 1)
                {
                    form.AddField("Crop", "Corn");
                }
                else if (Global.croptype[Global.season - 2, i] == 2)
                {
                    form.AddField("Crop", "Beans");
                }
                else
                {
                    form.AddField("Crop", "Mystery");
                }


                //Adding prior crop
                if (Global.season - 2 == 0)
                {
                    form.AddField("PriorHarvest", "None");
                }
                else
                {
                    if (Global.croptype[Global.season - 3, i] == 1)
                    {
                        form.AddField("PriorHarvest", "Corn");
                    }
                    else if (Global.croptype[Global.season - 3, i] == 2)
                    {
                        form.AddField("PriorHarvest", "Beans");
                    }
                    else if(Global.croptype[Global.season-3, i] == 3)
                    {
                        form.AddField("PriorHarvest", "Mystery");
                    }
                    else
                    {
                        form.AddField("PriorHarvest", "None");
                    }
                }

                form.AddField("Rain", (int)Global.raindata[Global.season - 2]);
                form.AddField("WaterAdded", Global.wateradded[Global.season - 2, i]);
                form.AddField("TotalWater", (int)(Global.wateradded[Global.season - 2, i] + Global.raindata[Global.season - 2]));
                form.AddField("Insects", BoolToInt(Global.pests[Global.season - 2, i]));
                int nitrate = Global.models[i].GetNitrateLevel();
                if (Global.composter)
                {
                    if (Global.croptype[Global.season - 2, i] == 1)
                    {
                        nitrate += 10;
                    }
                    else if (Global.croptype[Global.season - 2, i] == 2)
                    {
                        nitrate -= 10;
                    }
                    else
                    {
                        nitrate += 5;
                    }
                }
                else
                {

                    if (Global.croptype[Global.season - 2, i] == 1 && Global.season  >= 8)
                    {
                        nitrate += 25;
                    }
                    else if (Global.croptype[Global.season - 2, i] == 2 && Global.season >= 8)
                    {
                        nitrate -= 10;
                    }
                    else if (Global.croptype[Global.season-2, i] == 3 && Global.season >= 8)
                    {
                        nitrate += 15;
                    }
                }

                form.AddField("NitrateLevel", nitrate);
                form.AddField("PesticidesAdded", BoolToInt(Global.pestUsed[Global.season - 2, i]));
                form.AddField("Yield", Global.yielddata[Global.season - 2, i].ToString("F2"));
                form.AddField("Composter", BoolToInt(Global.composter));
                form.AddField("Irrigation", BoolToInt(Global.irrigation));
                if (Global.croptype[Global.season - 2, i] == 1)
                {
                    form.AddField("BuyPrice", Global.currCornSeed);
                    form.AddField("SellPrice", Global.currCornCrop);
                }
                else if (Global.croptype[Global.season - 2, i] == 2)
                {
                    form.AddField("BuyPrice", Global.currBeanSeed);
                    form.AddField("SellPrice", Global.currBeanCrop);
                }
                else
                {
                    form.AddField("BuyPrice", Global.currCarrotSeed);
                    form.AddField("SellPrice", Global.currCarrotCrop);
                }


                using (UnityWebRequest www = UnityWebRequest.Post("https://stat2games.sites.grinnell.edu/php/sendfarmgameinfo.php", form))
                {
                    yield return www.SendWebRequest();

                    if (www.downloadHandler.text == "0")
                    {
                        Debug.Log("Player data created successfully.");
                    }
                    else
                    {
                        Debug.Log("Player data creation failed. Error # " + www.downloadHandler.text);
                    }
                }
            }
        }


        //Send data click data
        WWWForm clickForm = new WWWForm();
        clickForm.AddField("GameNum", gameNum);
        clickForm.AddField("PlayerID", Global.username);
        clickForm.AddField("GroupID", Global.password);
        clickForm.AddField("Season", Global.season - 1);
        clickForm.AddField("DataTable", DataClicks.table);
        clickForm.AddField("Scatterplot", DataClicks.scatterplot);
        clickForm.AddField("xWater", DataClicks.xWater);
        clickForm.AddField("xYield", DataClicks.xYield);
        clickForm.AddField("xNitrate", DataClicks.xNitrate);
        clickForm.AddField("xSeason", DataClicks.xSeason);
        clickForm.AddField("xPlot", DataClicks.xPlot);
        clickForm.AddField("yYield", DataClicks.yYield);
        clickForm.AddField("yWater", DataClicks.yWater);
        clickForm.AddField("yNitrate", DataClicks.yNitrate);
        clickForm.AddField("ColorCrop", DataClicks.colorCrop);
        clickForm.AddField("RestrictAll", DataClicks.restrictAll);
        clickForm.AddField("RestrictCorn", DataClicks.restrictCorn);
        clickForm.AddField("RestrictBean", DataClicks.restrictBean);
        clickForm.AddField("RestrictMystery", DataClicks.restrictMystery);
        clickForm.AddField("ColorNitrate", DataClicks.colorNitrate);

        using (UnityWebRequest www = UnityWebRequest.Post("https://stat2games.sites.grinnell.edu/php/sendFarmClickData.php", clickForm))
        {
            yield return www.SendWebRequest();

            if (www.downloadHandler.text == "0")
            {
                Debug.Log("Click data created successfully.");
            }
            else
            {
                Debug.Log("Click data creation failed. Error # " + www.downloadHandler.text);
            }

            ResetClicks();
        }

    }

    private int BoolToInt(bool boolean)
    {
        if (boolean)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void ResetClicks()
    {
        DataClicks.table = 0;
        DataClicks.scatterplot = 0;
        DataClicks.xWater = 0;
        DataClicks.xYield = 0;
        DataClicks.xNitrate = 0;
        DataClicks.xSeason = 0;
        DataClicks.xPlot = 0;
        DataClicks.yYield = 0;
        DataClicks.yWater = 0;
        DataClicks.yNitrate = 0;
        DataClicks.colorCrop = 0;
        DataClicks.restrictAll = 0;
        DataClicks.restrictCorn = 0;
        DataClicks.restrictBean = 0;
        DataClicks.restrictMystery = 0;
        DataClicks.colorNitrate = 0;

    }
}



