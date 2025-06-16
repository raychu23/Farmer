using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject growButton;
    public GameObject nextButton;

    private void Start()
    {
        Global.loadCore = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetObjects("Clone1");
        SetObjects("Clone2");
        SetObjects("Clone3");
        SetObjects("Clone4");
        SetObjects("Clone5");
        SetObjects("Clone6");
        SetObjects("Selection");
        SetObjects("Pesticide");
    }

    private void SetObjects(string objTag)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objTag);
        foreach (GameObject obj in objs)
        {
            DontDestroyOnLoad(obj);
        }
    }
}
