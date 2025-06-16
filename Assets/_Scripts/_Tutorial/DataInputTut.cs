
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SLS.Widgets.Table;

public class DataInputTut : MonoBehaviour
{

    //public GameObject entryPrefab;
    private Table table;

    public int lastPos = 1;
    public int lastSeason = 1;

    // Use this for initialization
    void Start()
    {
        this.table = this.GetComponent<Table>();

        this.table.ResetTable();
        this.table.AddTextColumn("Season");
        this.table.AddTextColumn("Rain");
        this.table.AddTextColumn("Plot");
        this.table.AddTextColumn("Total Water");
        this.table.AddTextColumn("Crop Type");
        this.table.AddTextColumn("Yield");


        // Initialize Your Table
        this.table.Initialize(this.OnTableSelected);


        // Draw Your Table
        this.table.StartRenderEngine();
    }

    void Update()
    {
        if (lastSeason != TutorialGlobal.season)
        {

            for (int i = lastSeason; i < TutorialGlobal.season; i++)
            {
                RenderYield(i);
            }
        }

            lastSeason = TutorialGlobal.season;
    }

    public void RenderYield(int season)
    {
        for (int i = 0; i < 6; i++)
        {
            if (TutorialGlobal.plots[season - 1, i])
            {
                Datum d = Datum.Body(lastPos.ToString());
                d.elements.Add(season);
                d.elements.Add(TutorialGlobal.raindata[season - 1]);
                d.elements.Add(i + 1);
                d.elements.Add(TutorialGlobal.wateradded[season - 1, i] + TutorialGlobal.raindata[season - 1]);
                d.elements.Add(TutorialGlobal.croptype[season - 1, i]);
                d.elements.Add(TutorialGlobal.yielddata[season - 1, i]);

                Debug.Log(TutorialGlobal.plots[season - 1, i]);
                Debug.Log(i);
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

