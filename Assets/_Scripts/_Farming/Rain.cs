using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{

    public GameObject plot1;
    public GameObject plot2;
    public GameObject plot3;
    public GameObject plot4;
    public GameObject plot5;
    public GameObject plot6;
    public Display rainDisplay;
    public UpdateBoxDisplay rainBox;
   

    private void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void GetRain()
    {
        this.gameObject.SetActive(true);

        int rain = 0;
        float distribute = Random.Range(0, 100);

        if (Global.season == 1 || Global.season == 2 || Global.season == 3)
        {
            rain = Random.Range(20, 30);
        }
        //Force player to use watering can for seasons 4 and 5 and drought for seasons 15, 16, 17
        else if (Global.season == 4 || Global.season == 5 || Global.season == 15 || Global.season == 16 || Global.season == 17)
        {

            if (distribute < 20)
            {
                rain = Random.Range(5, 9);
            }
            else if (distribute < 80)
            {
                rain = Random.Range(10, 14);
            }
            else
            {
                rain = Random.Range(15, 17);
            }
        }
        else
        {

            if (distribute < 10)
            {
                rain = Random.Range(6, 10);
            }
            else if (distribute < 25)
            {
                rain = Random.Range(11, 14);
            }
            else if (distribute < 75)
            {
                rain = Random.Range(15, 23);
            }
            else if (distribute < 90)
            {
                rain = Random.Range(24, 27);
            }
            else
            {
                rain = Random.Range(28, 32);
            }


        }

        Models model1 = plot1.GetComponent<Farm>().model;
        Models model2 = plot2.GetComponent<Farm>().model;
        Models model3 = plot3.GetComponent<Farm>().model;
        Models model4 = plot4.GetComponent<Farm>().model;
        Models model5 = plot5.GetComponent<Farm>().model;
        Models model6 = plot6.GetComponent<Farm>().model;

        Global.raindata[Global.season - 1] = rain; 
        model1.AddRain(rain);
        model2.AddRain(rain);
        model3.AddRain(rain);
        model4.AddRain(rain);
        model5.AddRain(rain);
        model6.AddRain(rain);




        //Don't give user the choice to water on first season
        if (Global.season == 1 || Global.season == 2 || Global.season == 3)
        {
            if (Global.planted[0])
            {
                StartCoroutine(plot1.GetComponent<Farm>().Grow(1));
            }
            if (Global.planted[1])
            {
                StartCoroutine(plot2.GetComponent<Farm>().Grow(1));
            }
            if (Global.planted[2])
            {
                StartCoroutine(plot3.GetComponent<Farm>().Grow(1));
            }
            if (Global.planted[3])
            {
                StartCoroutine(plot4.GetComponent<Farm>().Grow(1));
            }
            if (Global.planted[4])
            {
                StartCoroutine(plot5.GetComponent<Farm>().Grow(1));
            }
            if (Global.planted[5])
            {
                StartCoroutine(plot6.GetComponent<Farm>().Grow(1));
            }
        }

        StartCoroutine(RainAnimation());
        rainDisplay.DisplayResource(rain.ToString());
        Global.rain = rain;
        rainBox.UpdateAmount(rain);

    }

    private IEnumerator RainAnimation()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
