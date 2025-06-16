using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScatter : MonoBehaviour
{
    public void OpenPlot()
    {
        Global.loadCore = true;
        SceneManager.LoadScene("Scatterplot");
    }

}
