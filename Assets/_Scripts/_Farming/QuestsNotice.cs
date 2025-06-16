using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsNotice : MonoBehaviour
{
    public GameObject questNotice;

    public void QuestInfo()
    {
        if(Global.season == 2){
            questNotice.SetActive(true);
        }
    }
}
