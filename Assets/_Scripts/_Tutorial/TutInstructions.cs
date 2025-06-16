using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutInstructions : MonoBehaviour
{
    public string[] instructions;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        text.SetText(instructions[TutorialGlobal.instructionNum]);
    }

    public void UpdateInstructions()
    {
        text.SetText(instructions[TutorialGlobal.instructionNum]);
    }
}
