using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Global.muted)
        {
            gameObject.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().mute = false;
        }
    }


    public void MuteSound()
    {
        Global.muted = !gameObject.GetComponent<AudioSource>().mute;
    }

}
