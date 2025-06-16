using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class FarmTut : MonoBehaviour
{
    public GameObject gameController;
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

    //Start position of seeds
    public float xStart;
    public float yStart;


    //Keep track of growth of crop
    private bool grown2;
    public string cloneName;

    //Model
    public Models model;
    public SubmitWaterButtonTut submit;

    //Keep track of slots
    private GameObject waterSelector;

    //Keep track of various displays
    public GameObject yieldDisplay;
    public GameObject waterDisplay;
    public GameObject data;
    public GameObject instructions;

    //Arrows and such
    public GameObject plotArrow1;
    public GameObject arrow2;
    public GameObject plotArrow2;
    public GameObject plotArrow3;
    public GameObject plotArrow4;
    public GameObject plotArrow5;
    public GameObject plotArrow6;

    public GameObject marketcircle;

    private bool firstload = true;

    //Errors
    public GameObject harvestError;

    //Keep track of plot and type of plant
    private int plantType;
    private int plot;

    //Keep track of buttons
    public GameObject rainButton;



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

        this.grown2 = TutorialGlobal.grown[plot - 1];
        model = TutorialGlobal.models[plot - 1];
        plantType = TutorialGlobal.croptype[TutorialGlobal.season - 1, this.plot - 1];

        waterSelector = GameObject.Find("WaterSelector").transform.GetChild(0).gameObject;

        //Display data button if season 3 or greater
        if (TutorialGlobal.season >= 4)
        {
            data.SetActive(true);
        }
     
    }

    private void Update()
    {
        if (TutorialGlobal.season >= 4)
        {
            data.SetActive(true);
        }
        TutorialGlobal.models[plot - 1] = this.model;

        if (TutorialGlobal.instructionNum == 2)
        {
            plotArrow1.SetActive(true);
            plotArrow2.SetActive(true);
            plotArrow3.SetActive(true);
            plotArrow4.SetActive(true);
            plotArrow5.SetActive(true);
            plotArrow6.SetActive(true);

        }
        else if (TutorialGlobal.instructionNum == 13)
        {
            marketcircle.SetActive(true);
            arrow2.SetActive(true);
        }
        else
        { 
            plotArrow1.SetActive(false);
            plotArrow2.SetActive(false);
            plotArrow3.SetActive(false);
            plotArrow4.SetActive(false);
            plotArrow5.SetActive(false);
            plotArrow6.SetActive(false);
            marketcircle.SetActive(false);
            arrow2.SetActive(false);
        }
    }

    //---------------Farming/Harvesting Animations------------------------//

    //Changes from seedling to sapling to full crop
    public IEnumerator Grow(int plant)
    {
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

        this.grown2 = true;
        TutorialGlobal.grown[plot - 1] = true;
    }

    private void DestroyClones()
    {
        GameObject[] crops = GameObject.FindGameObjectsWithTag(cloneName);
        foreach (GameObject crop in crops)
        {
            Destroy(crop);
        }
    }

    //Makes the given gameobject appear in the plot
    private void Plant(GameObject plant)
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

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }


    //------------- User Interaction and Model Implementation ----------------------//
    private void OnMouseDown()
    {
        //TUTORIAL: on first mouse click for any plot
        if (TutorialGlobal.instructionNum == 2)
        {
            GameObject.Find("GameController").GetComponent<TutorialController>().UpdateNum();
        }

        //Planting seeds on mouse click
        if (!TutorialGlobal.planted[plot - 1] && (TutorialGlobal.slotSelected == 1 || TutorialGlobal.slotSelected == 4 || TutorialGlobal.slotSelected == 6) && !TutorialGlobal.rained
            && (TutorialGlobal.instructionNum == 3 || TutorialGlobal.instructionNum == 5))
        {
            rainButton.SetActive(true);
            int seedNum = 0;
            GameObject seedObj = this.seed;
             plotArrow1.SetActive(false);
             plotArrow2.SetActive(false);

            //First type of seed selected
            if (TutorialGlobal.slotSelected == 1)
            {
                seedNum = TutorialGlobal.seeds;
                seedObj = this.seed;
                plantType = 1;
            }
            //Second type of seed selected
            else if (TutorialGlobal.slotSelected == 4 && TutorialGlobal.season >= 4)
            {
                seedNum = TutorialGlobal.seeds2;
                seedObj = this.seed_2;
                plantType = 2;
            }
            //Third type of seed selected
            else if (TutorialGlobal.slotSelected == 6 && TutorialGlobal.season >= 6)
            {
                seedNum = TutorialGlobal.seeds3;
                seedObj = this.seed_3;
                plantType = 3;
            }
            TutorialGlobal.croptype[TutorialGlobal.season - 1, this.plot - 1] = plantType;

                //Decrement seeds
                if (TutorialGlobal.slotSelected == 1)
                {
                    TutorialGlobal.seeds--;
                    if (TutorialGlobal.seeds == 0)
                    {
                        TutorialGlobal.slotSelected = -1;
                    }
                }
                else if (TutorialGlobal.slotSelected == 4)
                {
                    TutorialGlobal.seeds2--;
                    if (TutorialGlobal.seeds2 == 0)
                    {
                        TutorialGlobal.slotSelected = -1;
                    }
                }
                else
                {
                    TutorialGlobal.seeds3--;
                    if (TutorialGlobal.seeds3 == 0)
                    {
                        TutorialGlobal.slotSelected = -1;
                    }
                }

                //Plant the seed
                Plant(seedObj);
                TutorialGlobal.planted[this.plot - 1] = true;
                TutorialGlobal.harvest[this.plot - 1] = false;
        }
        //Add water 
        else if (!TutorialGlobal.grown[plot - 1] && TutorialGlobal.slotSelected == 3 && TutorialGlobal.season > 1 && TutorialGlobal.planted[plot - 1] && TutorialGlobal.rained)
        {


            //Reset plot if deselecting
            if (gameController.GetComponent<Multiselect>().plotsSelected[plot - 1])
            {
                gameController.GetComponent<Multiselect>().Undo(plot);
                Debug.Log("deselect plot " + this.plot);
                gameController.GetComponent<Multiselect>().plotsSelected[this.plot - 1] = false;

            }
            else
            {
                gameController.GetComponent<Multiselect>().Select(plot);
                Debug.Log("selected plot" + plot);
                waterSelector.SetActive(true);
                instructions.SetActive(false);
            }
            /*
            //Detect if shift key is pressed for multiselect 
            bool shiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            //Highlight plot if shift key is pressed
            if (shiftKeyDown)
            {
                gameController.GetComponent<Multiselect>().Select(plot);
            }

            //Indicate this plot is to be watered
            submit.selected[this.plot - 1] = true;

            //Ready to water
            if (!shiftKeyDown)
            {
                waterSelector.SetActive(true);
                instructions.SetActive(false);
                //Reset highlights
                for (int i = 1; i < 7; i++)
                {
                    if (submit.selected[i - 1])
                    {
                        gameController.GetComponent<Multiselect>().PrevSelect(i);
                    }
                }
            }
            */
        }
        //Harvesting: destroy all crops and increment inventory
        else if (TutorialGlobal.grown[plot - 1] && TutorialGlobal.planted[plot - 1]
                 && (TutorialGlobal.instructionNum ==4 || TutorialGlobal.instructionNum == 8))
        {
            TutorialGlobal.rained = false;
            TutorialGlobal.planted[this.plot - 1] = false;
            TutorialGlobal.harvest[this.plot - 1] = true;

            for (int i = 1; i < 7; i++)
            {
                gameController.GetComponent<Multiselect>().Reset(i);
            }

            DestroyClones();
            TutorialGlobal.grown[plot - 1] = false;

            int yield = 0;


            if (TutorialGlobal.croptype[TutorialGlobal.season - 1, this.plot - 1] == 1)
            {
                yield = Mathf.RoundToInt(model.GetYield1());
                TutorialGlobal.crops += yield;
            }
            else if (TutorialGlobal.croptype[TutorialGlobal.season - 1, this.plot - 1] == 2)
            {
                yield = Mathf.RoundToInt(model.GetYield2());
                TutorialGlobal.crops2 += yield;
            }
            else
            {
                yield = Mathf.RoundToInt(model.GetYield3());
                TutorialGlobal.crops3 += yield;
            }

            //Display harvest
            yieldDisplay.GetComponent<Display>().DisplayResource(yield.ToString());

            TutorialGlobal.yielddata[TutorialGlobal.season - 1, this.plot - 1] = yield;
            TutorialGlobal.plots[TutorialGlobal.season-1, plot - 1] = true;


            //Increase season if all plots are harvested
            if (this.AllHarvested())
            {
                instructions.SetActive(true);
                //Tutorial: intro to watering and data button
                if (TutorialGlobal.instructionNum == 4 || TutorialGlobal.instructionNum == 8)
                {
                    GameObject.Find("GameController").GetComponent<TutorialController>().UpdateNum();

                }

                Debug.Log("Season before:" + TutorialGlobal.season);
                TutorialGlobal.rained = false;
                //GameObject.Find("DatabaseSubmit").GetComponent<SubmitData>().SubmitUpload();
                TutorialGlobal.season++;
                rainBox.UpdateSeason(TutorialGlobal.season);
                Debug.Log("Season after:" + TutorialGlobal.season);

                if (TutorialGlobal.season > 2)
                {
                    data.SetActive(true);
                }

                //Render data
                TutorialGlobal.renderYieldData = true;
            }
        }


    }

    //-------------Miscellaneous---------
    public int GetPlantType()
    {
        return TutorialGlobal.croptype[TutorialGlobal.season - 1, this.plot - 1];
    }
    public bool AllPlanted()
    {
        foreach (bool plant in TutorialGlobal.planted)
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
        foreach (bool harvest in TutorialGlobal.harvest)
        {
            if (!harvest)
            {
                return false;
            }
        }
        return true;
    }

}
