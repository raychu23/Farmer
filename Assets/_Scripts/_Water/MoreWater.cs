using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class MoreWater : MonoBehaviour, IPointerDownHandler
{
    //Amount selected so far
    public int amount;
    public GameObject amountObj;
    public LessWater minusObj;

    //Amount available in inventory
    public GameObject inventory;

    void Start()
    {
        amount = int.Parse(amountObj.GetComponent<TextMeshProUGUI>().text);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(amount < inventory.GetComponent<Water>().amount)
        {
            this.amount++;
            minusObj.amount++;
            amountObj.GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        }
       
    }
}
