using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainTut : MonoBehaviour
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

        if (TutorialGlobal.season == 1)
        {
            rain = Random.Range(15, 30);
        }
        //As the game continues: drought so player must add water
        else
        {
            rain = Random.Range(1, 10);
        }

        Models model1 = plot1.GetComponent<FarmTut>().model;
        Models model2 = plot2.GetComponent<FarmTut>().model;
        Models model3 = plot3.GetComponent<FarmTut>().model;
        Models model4 = plot4.GetComponent<FarmTut>().model;
        Models model5 = plot5.GetComponent<FarmTut>().model;
        Models model6 = plot6.GetComponent<FarmTut>().model;

        TutorialGlobal.raindata[TutorialGlobal.season - 1] = rain;
        model1.AddRain(rain);
        model2.AddRain(rain);
        model3.AddRain(rain);
        model4.AddRain(rain);
        model5.AddRain(rain);
        model6.AddRain(rain);




        //Don't give user the choice to water on first season
        if (TutorialGlobal.season == 1)
        {
            if (TutorialGlobal.planted[0])
            {
                StartCoroutine(plot1.GetComponent<FarmTut>().Grow(1));
            }
            if (TutorialGlobal.planted[1])
            {
                StartCoroutine(plot2.GetComponent<FarmTut>().Grow(1));
            }
            if (TutorialGlobal.planted[2])
            {
                StartCoroutine(plot3.GetComponent<FarmTut>().Grow(1));
            }
            if (TutorialGlobal.planted[3])
            {
                StartCoroutine(plot4.GetComponent<FarmTut>().Grow(1));
            }
            if (TutorialGlobal.planted[4])
            {
                StartCoroutine(plot5.GetComponent<FarmTut>().Grow(1));
            }
            if (TutorialGlobal.planted[5])
            {
                StartCoroutine(plot6.GetComponent<FarmTut>().Grow(1));
            }
        }

        StartCoroutine(RainAnimation());
        rainDisplay.DisplayResource(rain.ToString());
        rainBox.UpdateAmount(rain);

    }

    private IEnumerator RainAnimation()
    {
        yield return new WaitForSeconds(3);
        //Tutorial
        if (TutorialGlobal.instructionNum == 3 || TutorialGlobal.instructionNum == 5)
        {
            GameObject.Find("GameController").GetComponent<TutorialController>().UpdateNum();
        }
        this.gameObject.SetActive(false);
    }
}
