using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCMessageDisplayer : MonoBehaviour
{ 
    public TextMeshProUGUI text;
    private string[] messages;
    private int currentIndex;

    public void SetMessages(string[] messageArr)
    {
        this.messages = messageArr;
        currentIndex = 0;
    }

    public void UpdateMessage()
    {
        if (currentIndex < messages.Length)
        {
            text.SetText(messages[currentIndex++]);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

}
