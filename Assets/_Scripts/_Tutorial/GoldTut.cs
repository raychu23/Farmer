using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldTut: MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().SetText(TutorialGlobal.gold.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().SetText(TutorialGlobal.gold.ToString());
    }
}
