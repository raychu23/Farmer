using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountInput : MonoBehaviour
{
    
    private InputField input;
    private string amount;
    
    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.GetComponent<InputField>();
        input.characterValidation =  InputField.CharacterValidation.Integer;
        input.onEndEdit.AddListener(SubmitAmount);
    }

    private void Update()
    {
        input.ActivateInputField();
    }

    private void SubmitAmount(string arg){
        this.amount = arg;
    }
    
    public int GetAmount(){
        return int.Parse(amount);
    }
    
    public void Reset(){
        amount = "0";
        input.SetTextWithoutNotify("");
    }
}
