using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;
using TMPro;
using UnityEngine.UI;


public class ScatterplotData : MonoBehaviour
{

    public GraphChart chart;
    private float[,] waterData;
    private float[,] seasonData;

    public TMP_Dropdown xAxis;
    public TMP_Dropdown yAxis;
    public TMP_Dropdown cropType;

    public TextMeshProUGUI xLabel;
    public TextMeshProUGUI yLabel;

    public Toggle colors;
    public Toggle nitrate;

    //Chart aspects
    private VerticalAxis vert;
    private HorizontalAxis hor;

    private float xMax;
    private float yMax;



    // Start is called before the first frame update
    void Start()
    {
        //Get the graph chart object
        GameObject graphChart = GameObject.Find("GraphChart");
        vert = graphChart.GetComponent<VerticalAxis>();
        hor = graphChart.GetComponent<HorizontalAxis>();

        waterData = new float[Global.raindata.Length, 6];

        //Initialize the water 2D-array
        for(int i = 1; i < Global.season; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                waterData[i - 1, j] = Global.wateradded[i - 1, j] + Global.raindata[i - 1];
            }
        }

        //Automatically do water vs yield first
        RewriteData(this.waterData, Global.yielddata);
        seasonData = new float[Global.raindata.Length, 6];

        //Initialize season as 2D array
        for(int i = 0; i < 6; i++)
        {
            for(int j = 1; j <= Global.raindata.Length; j++)
            {
                seasonData[j-1, i] = j;
            }
        }

    }

    public void ChangeAxes()
    {
        float[,] xValues = this.waterData;
        float[,] yValues = Global.yielddata;

        switch (xAxis.value)
        {
            //x axis is water
            case 0:
                xValues = this.waterData;
                xLabel.SetText("Water");
                break;
            //x axis is yield
            case 1:
                xValues = Global.yielddata;
                xLabel.SetText("Yield");
                break;
            //x axis is nitrate level
            case 2:
                xValues = Global.nitrate;
                xLabel.SetText("Nitrate");
                break;
            //x axis is season
            case 3:
                xValues = this.seasonData;
                xLabel.SetText("Season");
                break;
            //x axis is plot
            case 4:
                xValues = new float[Global.season, 6];
                for(int i = 0; i < Global.season; i++)
                {
                    for(int j = 1; j<=6;j++)
                    {
                        xValues[i,j-1] = j;
                    }
                }
                xLabel.SetText("Plot");
                break;
        }

        switch (yAxis.value)
        {
            //y axis is yield
            case 0:
                yValues = Global.yielddata;
                yLabel.SetText("Yield");
                break;
            //y axis is water
            case 1:
                yValues = this.waterData;
                yLabel.SetText("Water");
                break;
            //y axis is nitrate level
            case 2:
                yValues = Global.nitrate;
                yLabel.SetText("Nitrate");
                break;
        }

        RewriteData(xValues, yValues);
    }



    private void RewriteData(float[,] xData, float[,] yData)
    {
        chart.DataSource.StartBatch();
        chart.DataSource.ClearCategory("Corn");
        chart.DataSource.ClearCategory("Beans");
        chart.DataSource.ClearCategory("Mystery");
        chart.DataSource.ClearCategory("Crop");
        chart.DataSource.ClearCategory("Origin");
        chart.DataSource.ClearCategory("yAxis");
        chart.DataSource.ClearCategory("xAxis");
        chart.DataSource.ClearCategory("Nitrate1");
        chart.DataSource.ClearCategory("Nitrate2");
        chart.DataSource.ClearCategory("Nitrate3");
        chart.DataSource.ClearCategory("Nitrate4");
        chart.DataSource.ClearCategory("Nitrate5");
        chart.DataSource.ClearCategory("Nitrate6");



        //Find max values for both x and y
        xMax = 0;
        yMax = 0;


        for (int i = 1; i < Global.season; i++)
        {
            //Plant for each plot
            for (int j = 0; j < 6; j++)
            {
                //Color by crop
                if (colors.isOn)
                {
                    if (Global.croptype[i - 1, j] == 1 && (cropType.value == 0 || cropType.value == 1))
                    {
                        PlotPoint("Corn", xData[i - 1, j], yData[i - 1, j]);
                    }
                    else if (Global.croptype[i - 1, j] == 2 && (cropType.value ==0 || cropType.value == 2))
                    {
                        PlotPoint("Beans", xData[i - 1, j], yData[i - 1, j]);
                    }
                    else if (Global.croptype[i - 1, j] == 3 && (cropType.value ==0 || cropType.value == 3))
                    {
                        PlotPoint("Mystery", xData[i - 1, j], yData[i - 1, j]);
                    }
                }
                //Color by nitrate
                else if (nitrate.isOn)
                {
                    if (Global.croptype[i - 1, j] == 1 && (cropType.value == 0 || cropType.value == 1))
                    {
                        PlotNitrate(Global.nitrate[i-1,j], xData[i - 1, j], yData[i - 1, j]);
                    }
                    else if (Global.croptype[i - 1, j] == 2 && (cropType.value == 0 || cropType.value == 2))
                    {
                        PlotNitrate(Global.nitrate[i - 1, j], xData[i - 1, j], yData[i - 1, j]);
                    }
                    else if (Global.croptype[i - 1, j] == 3 && (cropType.value == 0 || cropType.value == 3))
                    {
                        PlotNitrate(Global.nitrate[i - 1, j], xData[i - 1, j], yData[i - 1, j]);
                    }
                }
                else
                {
                    //Plot all of them the same color
                    if (Global.croptype[i - 1, j] == 1 && (cropType.value == 0 || cropType.value == 1))
                    {
                        PlotPoint("Crop", xData[i - 1, j], yData[i - 1, j]);
                    }
                    else if (Global.croptype[i - 1, j] == 2 && (cropType.value == 0 || cropType.value == 2))
                    {
                        PlotPoint("Crop", xData[i - 1, j], yData[i - 1, j]);
                    }
                    else if (Global.croptype[i - 1, j] == 3 && (cropType.value == 0 || cropType.value == 3))
                    {
                        PlotPoint("Crop", xData[i - 1, j], yData[i - 1, j]);
                    }
                }

            } //for plot
        } // for season


        //If there are points to plot, make sure origin is on graph
        if(yMax - 0 > 0.02 || xMax - 0 > 0.02)
        {
            chart.DataSource.AddPointToCategory("Origin", 0, 0);
        }


        //Set the y-axis
        if (yMax < 5)
        {
            vert.MainDivisions.UnitsPerDivision = 1;
        }
        else if (yMax < 10)
        {
            vert.MainDivisions.UnitsPerDivision = 2;
            chart.DataSource.AddPointToCategory("yAxis", 0, yMax + 2);
        }
        else if (yMax < 30)
        {
            vert.MainDivisions.UnitsPerDivision = 5;
            chart.DataSource.AddPointToCategory("yAxis", 0, yMax + 5);
        }
        else if (yMax < 50)
        {
            vert.MainDivisions.UnitsPerDivision = 10;
            chart.DataSource.AddPointToCategory("yAxis", 0, yMax + 10);
        }
        else if (yMax < 75)
        {
            vert.MainDivisions.UnitsPerDivision = 15;
            chart.DataSource.AddPointToCategory("yAxis", 0, yMax + 15);

        }
        else if (yMax < 100)
        {
            vert.MainDivisions.UnitsPerDivision = 20;
            chart.DataSource.AddPointToCategory("yAxis", 0, yMax + 20);

        }
        else if (yMax < 200)
        {
            vert.MainDivisions.UnitsPerDivision = 40;
            chart.DataSource.AddPointToCategory("yAxis", 0, yMax + 40);
        }
        else if (yMax < 400)
        {
            vert.MainDivisions.UnitsPerDivision = 80;
            chart.DataSource.AddPointToCategory("yAxis", 0, yMax + 80);
        }
        else if(yMax < 600)
        {
            vert.MainDivisions.UnitsPerDivision = 100;
            chart.DataSource.AddPointToCategory("yAxis", 0, yMax + 100);
        }
        else
        {
            vert.MainDivisions.UnitsPerDivision = 150;
            chart.DataSource.AddPointToCategory("yAxis", 0, yMax + 150);
        }



        //Set the x-axis
        if (xMax < 10)
        {
            hor.MainDivisions.UnitsPerDivision = 1;
        }
        else if (xMax < 16)
        {
            hor.MainDivisions.UnitsPerDivision = 2;
            chart.DataSource.AddPointToCategory("xAxis", xMax + 2, 0);
        }
        else if (xMax < 35)
        {
            hor.MainDivisions.UnitsPerDivision = 5;
            chart.DataSource.AddPointToCategory("xAxis", xMax + 5, 0);
        }
        else if (xMax < 50)
        {
            hor.MainDivisions.UnitsPerDivision = 10;
            chart.DataSource.AddPointToCategory("xAxis", xMax + 10, 0);
        }
        else if (xMax < 80)
        {
            hor.MainDivisions.UnitsPerDivision = 15;
            chart.DataSource.AddPointToCategory("xAxis", xMax + 15, 0);

        }
        else if (xMax < 100)
        {
            hor.MainDivisions.UnitsPerDivision = 20;
            chart.DataSource.AddPointToCategory("xAxis", xMax + 20, 0);

        }
        else if (xMax < 200)
        {
            hor.MainDivisions.UnitsPerDivision = 40;
            chart.DataSource.AddPointToCategory("xAxis", xMax + 40, 0);
        }
        else if (xMax < 400)
        {
            hor.MainDivisions.UnitsPerDivision = 80;
            chart.DataSource.AddPointToCategory("xAxis", xMax + 80, 0);
        }
        else
        {
            hor.MainDivisions.UnitsPerDivision = 100;
            chart.DataSource.AddPointToCategory("xAxis", xMax + 100, 0);
        }


        chart.DataSource.EndBatch();
    }



    //---------------Helpers-----------------

    private void PlotPoint(string pointName, float x, float y)
    {
        //Plot in correct group
        chart.DataSource.AddPointToCategory(pointName, x, y);
        yMax = Mathf.Max(yMax, y);
        xMax = Mathf.Max(xMax, x);
    }

    private void PlotNitrate(float nitrateLevel, float x, float y)
    {
        if(nitrateLevel < 200)
        {
            PlotPoint("Nitrate1", x, y);
        }
        else if(nitrateLevel < 250)
        {
            PlotPoint("Nitrate2", x, y);
        }
        else if (nitrateLevel < 300)
        {
            PlotPoint("Nitrate3", x, y);
        }
        else if (nitrateLevel < 350)
        {
            PlotPoint("Nitrate4", x, y);
        }
        else if (nitrateLevel < 400)
        {
            PlotPoint("Nitrate5", x, y);
        }
        else
        {
            PlotPoint("Nitrate6", x, y);
        }
    }
}