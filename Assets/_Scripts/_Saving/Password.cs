using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Password : MonoBehaviour
{
    private TMP_InputField input;

    void Start()
    {
        input = gameObject.GetComponent<TMP_InputField>();
        input.onEndEdit.AddListener(UpdatePass);
        if (Global.tutorial)
        {
            input.text = Global.password;
        }
    }

    private void UpdatePass(string arg)
    {
        Global.password = arg;
    }

}
