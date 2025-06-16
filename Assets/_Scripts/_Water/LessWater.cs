using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class LessWater : MonoBehaviour, IPointerDownHandler
{
    public int amount;
    private GameObject amountObj;
    public MoreWater plusObj;

    void Start()
    {
        amountObj = this.transform.parent.GetChild(4).GetChild(1).gameObject;
        amount = int.Parse(amountObj.GetComponent<TextMeshProUGUI>().text);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (amount > 0)
        {
            this.amount--;
            plusObj.amount--;
            amountObj.GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        }
    }


}
