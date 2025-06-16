using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class SlotTut : MonoBehaviour, IPointerDownHandler
{
    private int amount;

    private GameObject imageObj;
    private GameObject amountObj;
    public int slotNumber;
    public GameObject dataButton;

    // Start is called before the first frame update
    void Start()
    {
        imageObj = this.transform.GetChild(1).gameObject;
        amountObj = this.transform.GetChild(3).gameObject;
        imageObj.SetActive(false);

        if (this.slotNumber == 1)
        {
            amount = TutorialGlobal.seeds;
            imageObj.SetActive(true);
            amountObj.GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        }

        TutorialGlobal.slotSelected = -1;
    }

    private void Update()
    {

        if (this.slotNumber == 1)
        {
            amount = TutorialGlobal.seeds;
            //if (TutorialGlobal.instructionNum <= 2)
            //{
            //    this.transform.GetChild(5).gameObject.SetActive(true);
            //}
            //else
            //{
            //    this.transform.GetChild(5).gameObject.SetActive(false);
            //}
        }
        else if (this.slotNumber == 2)
        {
            amount = TutorialGlobal.crops;
        }

        //Introduce water at tutorial step 7
        if (TutorialGlobal.instructionNum >= 6)
        {
            if (this.slotNumber == 3)
            {
                amount = TutorialGlobal.water;
                this.gameObject.SetActive(true);
            }
        }

        if (TutorialGlobal.instructionNum == 1 && this.slotNumber == 1)
        {
            this.transform.GetChild(5).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(5).gameObject.SetActive(false);
        }

        if (TutorialGlobal.instructionNum == 6 && this.slotNumber == 3)
        {
            this.transform.GetChild(5).gameObject.SetActive(true);
            dataButton.SetActive(true);
        }
        else
        {
            this.transform.GetChild(5).gameObject.SetActive(false);
        }


        //Show image if there are more than 0 in inventory
        if (amount > 0)
        {
            imageObj.SetActive(true);
            amountObj.SetActive(true);
            amountObj.GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        }
        else
        {
            imageObj.SetActive(false);
            amountObj.SetActive(false);
            //Don't let the slot be selected
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(5).gameObject.SetActive(false);
        }

    }

    public void Deselect()
    {
        this.transform.GetChild(4).gameObject.SetActive(false);
    }

    //Selection of a slot
    public void OnPointerDown(PointerEventData eventData)
    {
        //TUTORIAL: first click updates 
        if(this.slotNumber == 1 && TutorialGlobal.instructionNum == 1)
        {
            GameObject.Find("GameController").GetComponent<TutorialController>().UpdateNum();

        }

        //TUTORIAL: Watering 
        if (this.slotNumber == 3 && TutorialGlobal.instructionNum == 6)
        {
            GameObject.Find("GameController").GetComponent<TutorialController>().UpdateNum();

        }

        //Deselect previously selected slot
        if (TutorialGlobal.slotSelected != this.slotNumber && TutorialGlobal.instructionNum > 0)
        {
            if (TutorialGlobal.slotSelected != -1)
            {
                this.transform.parent.GetChild(TutorialGlobal.slotSelected).GetComponent<SlotTut>().Deselect();
            }

            //Set this slot active
            if (this.amount > 0)
            {
                this.transform.GetChild(4).gameObject.SetActive(true);
                TutorialGlobal.slotSelected = this.slotNumber;
            }

        }
        //Deselect all slots
        else
        {
            this.Deselect();
            TutorialGlobal.slotSelected = -1;
        }
    }


}
