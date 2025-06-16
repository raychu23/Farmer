using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using SLS.Widgets.Table;

public class Farm : MonoBehaviour
{
    public GameObject gameController;
    public GameObject notifications;
    public UpdateBoxDisplay rainBox;

    //Sprites and animations for first type of crop
    public GameObject seed;
    public GameObject grow1;
    public GameObject grow2;
    public GameObject rain;

    //Sprites and animations for second type of crop
    public GameObject seed_2;
    public GameObject grow1_2;
    public GameObject grow2_2;

    //Sprites and animations for third type of crop
    public GameObject seed_3;
    public GameObject grow1_3;
    public GameObject grow2_3;

    //Pesticides
    public GameObject pests;
    public GameObject pesticide;

    //Start position of seeds
    public float xStart;
    public float yStart;


    //Keep track of growth of crop
    private bool growing;
    public string cloneName;

    //Model
    public Models model;
    public SubmitWaterButton submit;

    //Keep track of slots
    private GameObject waterSelector;

    //Keep track of various displays
    public GameObject yieldDisplay;
    public GameObject fertDisplay;
    public GameObject data;
    public GameObject info;

    //Errors
    public GameObject harvestError;
    public GameObject rainError;
    public GameObject storageError;

    //Keep track of plot and type of plant
    private int plantType;
    private int plot;

    //Keep track of buttons
    public GameObject rainButton;

    //Quests
    public Quests questButton;
    public QuestTracker questTracker;

    //Sound
    public Sound sound;



    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
        rain.SetActive(false);


        if (this.tag.CompareTo("Plot1") == 0)
        {
            this.plot = 1;    
        }
        else if (this.tag.CompareTo("Plot2") == 0)
        {
            this.plot = 2;
        }
        else if (this.tag.CompareTo("Plot3") == 0)
        {
            this.plot = 3;
        }
        else if (this.tag.CompareTo("Plot4") == 0)
        {
            this.plot = 4;
        }
        else if (this.tag.CompareTo("Plot5") == 0)
        {
            this.plot = 5;
        }
        else
        {
            this.plot = 6;
        }

        this.growing = false;
        model = Global.models[plot-1];
        plantType = Global.croptype[Global.season - 1, this.plot - 1];
        waterSelector = GameObject.Find("WaterSelector").transform.GetChild(0).gameObject;

        if(Global.season == 1)
        {
            Global.nitrate[0, plot - 1] = 100;
        }
    }

    private void Update()
    {
        if (Global.season >= 4)
        {
            data.SetActive(true);
        }
        Global.models[plot - 1] = this.model;


    }

    //---------------Farming/Harvesting Animations------------------------//

    //Changes from seedling to sapling to full crop
    public IEnumerator Grow(int plant)
    {
        this.growing = true;

        yield return new WaitForSeconds(1);
        //Destroy all seeds and plant saplings
        DestroyClones();


        if (plant == 1)
        {
            Plant(grow1);
        }
        else if (plant == 2)
        {
            Plant(grow1_2);
        }
        else
        {
            Plant(grow1_3);
        }

        yield return new WaitForSeconds(1);

        //Destroy all saplings and plant full crops
        DestroyClones();
        StartCoroutine(Wait());

        if (plant == 1)
        {
            Plant(grow2);
        }
        else if (plant == 2)
        {
            Plant(grow2_2);
        }
        else
        {
            Plant(grow2_3);
        }
        Global.grown[plot - 1] = true;
        this.growing = false;
        if (Global.pests[Global.season - 1, plot - 1])
        {
            Plant(pests);
        }
    }

    private void DestroyClones()
    {
        GameObject[] crops = GameObject.FindGameObjectsWithTag(cloneName);
        foreach (GameObject crop in crops)
        {
            Destroy(crop);
        }

        GameObject[] pesticides = GameObject.FindGameObjectsWithTag("Pesticide");
        foreach (GameObject pesti in pesticides)
        {
            Destroy(pesti);
        }
    }

    //Makes the given gameobject appear in the plot
    public void Plant(GameObject plant)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject clone = Instantiate(plant, new Vector3(xStart + (0.15f * i), yStart - (.15f * j), -0.1f), Quaternion.identity);
                clone.tag = cloneName;
            }
        }
    }


    //Makes the given gameobject appear in the plot
    public void Pesticide(GameObject pesticide)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject clone = Instantiate(pesticide, new Vector3(xStart + (0.15f * i), yStart - (.15f * j), -0.1f), Quaternion.identity);
                clone.tag = "Pesticide";
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }


    //------------- User Interaction and Model Implementation ----------------------//
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
           //Debug.Log("Clicked on the UI");
        }
        else
        {
            //Planting seeds on mouse click
            if (!Global.planted[plot-1] && (Global.slotSelected == 1 || Global.slotSelected == 4 || Global.slotSelected == 6))
            {
                if (Global.rained)
                {
                    harvestError.SetActive(true);
                }
                else
                {
                    sound.PlaySeedingSound();
                    rainButton.SetActive(true);
                    int seedNum = 0;
                    GameObject seedObj = this.seed;

                    //First type of seed selected
                    if (Global.slotSelected == 1)
                    {
                        seedNum = Global.seeds;
                        seedObj = this.seed;
                        plantType = 1;
                    }
                    //Second type of seed selected
                    else if (Global.slotSelected == 4 && Global.season >= 4)
                    {
                        seedNum = Global.seeds2;
                        seedObj = this.seed_2;
                        plantType = 2;
                    }
                    //Third type of seed selected
                    else if (Global.slotSelected == 6 && Global.season >= 6)
                    {
                        seedNum = Global.seeds3;
                        seedObj = this.seed_3;
                        plantType = 3;
                    }

                    //Double size of all arrays if we run out of space
                    if (Global.season - 1 >= (Global.raindata.Length))
                    {
                        int newLength = Global.raindata.Length * 2;
                        Debug.Log("doubling all array sizes");
                        float[] newRain = new float[newLength];
                        float[,] newYield = new float[newLength, 6];
                        int[,] newWaterAdded = new int[newLength, 6];
                        int[,] newCrop = new int[newLength, 6];
                        float[,] newNitrate = new float[newLength, 6];
                        bool[,] newPlots = new bool[newLength, 6];
                        bool[,] newPests = new bool[newLength, 6];
                        bool[,] pesticides = new bool[newLength, 6];
                        int[] cornSeed = new int[newLength];
                        int[] beanSeed = new int[newLength];
                        int[] carrotSeed = new int[newLength];
                        int[] cornCrop = new int[newLength];
                        int[] beanCrop = new int[newLength];
                        int[] carrotCrop = new int[newLength];


                        for (int i = 0; i < newLength / 2; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                newRain[i] = Global.raindata[i];
                                newYield[i, j] = Global.yielddata[i, j];
                                newWaterAdded[i, j] = Global.wateradded[i, j];
                                newCrop[i, j] = Global.croptype[i, j];
                                newNitrate[i, j] = Global.nitrate[i, j];
                                newPlots[i, j] = Global.plots[i, j];
                                newPests[i, j] = Global.pests[i, j];
                                pesticides[i, j] = Global.pestUsed[i, j];
                                cornSeed[i] = Global.cornSeed[i];
                                beanSeed[i] = Global.beanSeed[i];
                                carrotSeed[i] = Global.carrotSeed[i];
                                cornCrop[i] = Global.cornCrop[i];
                                beanCrop[i] = Global.beanCrop[i];
                                carrotCrop[i] = Global.carrotCrop[i];
                            }
                        }
                        Global.raindata = newRain;
                        Global.yielddata = newYield;
                        Global.wateradded = newWaterAdded;
                        Global.croptype = newCrop;
                        Global.nitrate = newNitrate;
                        Global.plots = newPlots;
                        Global.pests = newPests;
                        Global.pestUsed = pesticides;
                        Global.cornSeed = cornSeed;
                        Global.beanSeed = beanSeed;
                        Global.carrotSeed = carrotSeed;
                        Global.cornCrop = cornCrop;
                        Global.beanCrop = beanCrop;
                        Global.carrotCrop = carrotCrop;
                    }

                    Global.croptype[Global.season - 1, this.plot - 1] = plantType;

                    //Decrement seeds
                    if (Global.slotSelected == 1)
                    {
                        Global.seeds--;
                        if (Global.seeds == 0)
                        {
                            Global.slotSelected = -1;
                        }
                    }
                    else if (Global.slotSelected == 4)
                    {
                        Global.seeds2--;
                        if (Global.seeds2 == 0)
                        {
                            Global.slotSelected = -1;
                        }
                    }
                    else
                    {
                        Global.seeds3--;
                        if (Global.seeds3 == 0)
                        {
                            Global.slotSelected = -1;
                        }
                    }

                    //Plant the seed
                    Plant(seedObj);
                    Global.planted[this.plot - 1] = true;
                    Global.harvest[this.plot - 1] = false;
                }
               
            }
            //Add water 
            else if (!this.growing && !Global.grown[plot-1] && Global.slotSelected == 3 && Global.season > 3 && Global.planted[plot-1])
            {
                if (!Global.rained)
                {
                    rainError.SetActive(true);
                }
                else
                {
                    sound.PlayInventorySound();
                    //Reset plot if deselecting
                    if (gameController.GetComponent<Multiselect>().plotsSelected[plot - 1])
                    {
                        gameController.GetComponent<Multiselect>().Undo(plot);
                        gameController.GetComponent<Multiselect>().plotsSelected[this.plot - 1] = false;

                    }
                    //Select plot
                    else
                    {
                        gameController.GetComponent<Multiselect>().Select(plot);
                        waterSelector.SetActive(true);
                    }
                }
              
            }
            //Add fertilizer
            else if (!Global.grown[plot - 1] && Global.slotSelected == 8 && Global.season > 9 && Global.fertilizer > 0)
            {
                model.AddFertilizer(plot);
                Global.fertilizer--;
                Global.fertUsed++;
                fertDisplay.GetComponent<Display>().DisplayResource("50");
            }
            //Add pesticides
            else if (!Global.grown[plot - 1] && Global.slotSelected == 9 && Global.season > 9)
            {
                model.AddPesticides(plot);
                Global.pesticides--;
                Pesticide(pesticide);
            }
            //Harvesting: destroy all crops and increment inventory
            else if (Global.grown[plot-1] && Global.planted[plot-1])
            {
                float yield = 0;

                //model.SetPest(plot);

                if (Global.croptype[Global.season - 1, this.plot - 1] == 1)
                {
                    yield = model.GetYield1();
                }
                else if (Global.croptype[Global.season - 1, this.plot - 1] == 2)
                {
                    yield = model.GetYield2();
                }
                else
                {
                    yield = model.GetYield3();
                }

                if ((!Global.silo && (Global.crops + Global.crops2 + Global.crops3 + Mathf.RoundToInt(yield) > 200))
                     || (Global.silo && (Global.crops + Global.crops2 + Global.crops3 + Mathf.RoundToInt(yield) > 400)))
                {
                    storageError.SetActive(true);
                }
                else
                {
                    if (Global.croptype[Global.season - 1, this.plot - 1] == 1)
                    {
                        Global.crops += Mathf.RoundToInt(yield);
                    }
                    else if (Global.croptype[Global.season - 1, this.plot - 1] == 2)
                    {
                        Global.crops2 += Mathf.RoundToInt(yield);
                    }
                    else
                    {
                        Global.crops3 += Mathf.RoundToInt(yield);
                    }

                    sound.PlayHarvestSound();
                    Global.planted[this.plot - 1] = false;
                    Global.harvest[this.plot - 1] = true;

                    for (int i = 1; i < 7; i++)
                    {
                        gameController.GetComponent<Multiselect>().Reset(i);
                    }

                    DestroyClones();
                    Global.grown[plot - 1] = false;



                    //Display harvest
                    yieldDisplay.GetComponent<Display>().DisplayResource(Mathf.RoundToInt(yield).ToString());

                    Global.yielddata[Global.season - 1, this.plot - 1] = yield;
                    Global.plots[Global.season - 1, plot - 1] = true;
                    model.UpdateNitrate(plot);
                    Global.nitrateUpdated[plot - 1] = true;

                    //Increase season if all plots are harvested
                    if (this.AllHarvested())
                    {
                        Global.rained = false;
                        GameObject.Find("DatabaseSubmit").GetComponent<SubmitData>().SubmitUpload();
                        Global.renderYieldData = true;


                        //Store nitrate updates
                        for (int i = 0; i < 6; i++)
                        {
                            if (!Global.nitrateUpdated[i])
                            {
                                Global.models[i].UpdateNitrate(i + 1);
                            }
                            Global.nitrateUpdated[i] = false;
                        }

                        //Store price updates
                        Global.cornSeed[Global.season - 1] = Global.currCornSeed;
                        Global.beanSeed[Global.season - 1] = Global.currBeanSeed;
                        Global.carrotSeed[Global.season - 1] = Global.currCarrotSeed;
                        Global.cornCrop[Global.season - 1] = Global.currCornCrop;
                        Global.beanCrop[Global.season - 1] = Global.currBeanCrop;
                        Global.carrotCrop[Global.season - 1] = Global.currCarrotCrop;


                        //Check quests
                        questTracker.CheckQuests();

                        //Calculate fine
                        gameController.GetComponent<Fine>().CalculateFine(Global.fertUsed, Global.pestUsed);
                        Global.fertUsed = 0;

                        //Update season
                        Global.season++;
                        questButton.UpdateQuest();
                        rainBox.UpdateSeason(Global.season);
                        Global.renderRainData = false;
                        this.notifications.GetComponent<Info>().RenderInfo();
                        if (Global.season >= 4)
                        {
                            data.SetActive(true);
                        }

                    }
                }

            }

        }

    }

    //-------------Miscellaneous---------
    public int GetPlotNum()
    {
        return this.plot;
    }

    public int GetPlantType()
    {
        return Global.croptype[Global.season - 1, this.plot - 1];
    }

    public IEnumerator GetInfo()
    {
        yield return new WaitForSeconds(1);
        info.GetComponent<Info>().RenderInfo();
    }

    public bool AllPlanted()
    {
        foreach (bool plant in Global.planted)
        {
            if (!plant)
            {
                return false;
            }
        }
        return true;
    }

    public bool AllHarvested()
    {
        foreach(bool harvest in Global.harvest)
        {
            if (!harvest)
            {
                return false;
            }
        }
        return true;
    }

}
