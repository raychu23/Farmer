using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTracker : MonoBehaviour
{

    private int message;
    public GameObject displayer;

    public void SetMessage(int num)
    {
        message = num;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        displayer.SetActive(true);
        NPCMessage messages = this.gameObject.GetComponent<NPCMessage>();
        NPCMessageDisplayer messageDisplayer = displayer.GetComponent<NPCMessageDisplayer>();

        switch (message)
        {
            case 1:
                messageDisplayer.SetMessages(messages.messages1);
                messageDisplayer.UpdateMessage();
                break;
            case 2:
                messageDisplayer.SetMessages(messages.messages2);
                messageDisplayer.UpdateMessage();
                break;
            case 3:
                messageDisplayer.SetMessages(messages.messages3);
                messageDisplayer.UpdateMessage();
                break;
            case 4:
                messageDisplayer.SetMessages(messages.messages4);
                messageDisplayer.UpdateMessage();
                break; 
        }
    }

    public void OnMouseDown()
    {
        displayer.SetActive(true);
        NPCMessage messages = this.gameObject.GetComponent<NPCMessage>();
        NPCMessageDisplayer messageDisplayer = displayer.GetComponent<NPCMessageDisplayer>();

        switch (message)
        {
            case 1:
                messageDisplayer.SetMessages(messages.messages1);
                messageDisplayer.UpdateMessage();
                break;
            case 2:
                messageDisplayer.SetMessages(messages.messages2);
                messageDisplayer.UpdateMessage();
                break;
            case 3:
                messageDisplayer.SetMessages(messages.messages3);
                messageDisplayer.UpdateMessage();
                break;
            case 4:
                messageDisplayer.SetMessages(messages.messages4);
                messageDisplayer.UpdateMessage();
                break;
        }
    }
}
