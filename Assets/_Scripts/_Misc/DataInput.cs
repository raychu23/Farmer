
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SLS.Widgets.Table;

public class DataInput : MonoBehaviour
{

    //public GameObject entryPrefab;
    private Table table;

    public int lastPos = 1;
    public int lastSeason = 4;
    public bool rainRendered = false;
    private bool firstRender = true;

    // Use this for initialization
    void Start()
    {
        this.table = this.GetComponent<Table>();

        this.table.ResetTable();
        this.table.AddTextColumn("Season");
        this.table.AddTextColumn("Rain");
        this.table.AddTextColumn("Plot");
        this.table.AddTextColumn("Total Water");
        this.table.AddTextColumn("Yield");
        this.table.AddTextColumn("Crop Type");
        this.table.AddTextColumn("Buy Price");
        this.table.AddTextColumn("Sale Price");
       // this.table.AddTextColumn("Profit");



        // Initialize Your Table
        this.table.Initialize(this.OnTableSelected);
       

        // Draw Your Table
        this.table.StartRenderEngine();
    }

    void Update()
    {

        if (this.firstRender)
        {
            for(int i = 1; i < 4; i++)
            {
                RenderYield(i);
            }
            firstRender = false;
        }

        if (lastSeason != Global.season)
        {
                for (int i = lastSeason; i < Global.season; i++)
                {
                    RenderYield(i);
                }
            lastSeason = Global.season;
       }
    }

    public void RenderYield(int season)
    {
        for(int i = 0; i < 6; i++)
        {
            if (Global.plots[season-1, i])
            {
                Datum d = Datum.Body(lastPos.ToString());
                d.elements.Add(season);
                d.elements.Add((int)Global.raindata[season-1]);
                d.elements.Add(i+1);
                d.elements.Add((int)(Global.wateradded[season-1, i] + Global.raindata[season-1]));
                d.elements.Add(Mathf.RoundToInt(Global.yielddata[season - 1, i]));
                if (Global.croptype[season - 1, i] == 1)
                {
                    d.elements.Add("Corn");

                    //Adding prices
                    d.elements.Add(Global.cornSeed[season - 1]);
                    d.elements.Add(Global.cornCrop[season - 1]);
             //       d.elements.Add(Global.cornCrop[season - 1] - Global.cornSeed[season-1]);

                }
                else if (Global.croptype[season - 1, i] == 2)
                {
                    d.elements.Add("Beans");
                    d.elements.Add(Global.beanSeed[season - 1]);
                    d.elements.Add(Global.beanCrop[season - 1]);
                 //  d.elements.Add(Global.beanCrop[season - 1] - Global.beanSeed[season - 1]);
                }
                else
                {
                    d.elements.Add("Mystery");
                    d.elements.Add(Global.carrotSeed[season - 1]);
                    d.elements.Add(Global.carrotCrop[season - 1]);
                //   d.elements.Add(Global.carrotCrop[season - 1] - Global.carrotSeed[season - 1]);
                }

                this.table.data.Add(d);
                this.lastPos++;
            }
        }
    }




    private void OnTableSelected(Datum datum, Column column)
    {
        string cidx = "N/A";
        if (column != null)
        {
            cidx = column.idx.ToString();
        }
        print("You Clicked: " + datum.uid + " Column: " + cidx);
    }
}

