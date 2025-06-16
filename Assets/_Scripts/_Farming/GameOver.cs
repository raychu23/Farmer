using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;

    // Update is called once per frame
    void Update()
    {
        if ((Global.gold <= 0) && (Global.crops <= 0) && (Global.crops2 <= 0) && (Global.crops3 <= 0) && (Global.seeds <= 0) && (Global.seeds2 <= 0) && (Global.seeds3 <= 0))
        {
            gameOverCanvas.GetComponent<Info>().GameOver();
        }
    }
}
