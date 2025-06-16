using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int amount;

    private GameObject imageObj;
    private GameObject amountObj;
    public int slotNumber;
    public Sound invSound;

    // Start is called before the first frame update
    void Start()
    {
        imageObj = this.transform.GetChild(1).gameObject;
        amountObj = this.transform.GetChild(3).gameObject;
        imageObj.SetActive(false);

        if (this.slotNumber == 1)
        {
            amount = Global.seeds;
            imageObj.SetActive(true);
            amountObj.GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        }

        Global.slotSelected = -1;
    }

    private void Update()
    {

        if (this.slotNumber == 1)
        {
            amount = Global.seeds;
        }
        else if (this.slotNumber == 2)
        {
            amount = Global.crops;
        }

        //Introduce second type of crop at season 6
        if (Global.season >= 6)
        {
            if (this.slotNumber == 4)
            {
                amount = Global.seeds2;
            }
            else if (this.slotNumber == 5)
            {
                amount = Global.crops2;
            }
        }

        //Introduce last type of crop at season 9
        if (Global.season >= 9)
        {
            if (this.slotNumber == 6)
            {
                amount = Global.seeds3;
            }
            else if (this.slotNumber == 7)
            {
                amount = Global.crops3;
            }
        }

        //Introduce fertilizer at season 10
        if (Global.season >= 10)
        {
            if (this.slotNumber == 8)
            {
                amount = Global.fertilizer;
            }
        }

        //Introduce pesticide at season 20
        if (Global.season >= 20)
        {
            if (this.slotNumber == 9)
            {
                amount = Global.pesticides;
            }
        }
        

        //Show image if there are more than 0 in inventory
        if (amount > 0)
        {
            imageObj.SetActive(true);
            amountObj.GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        }
        else
        {
            imageObj.SetActive(false);
            amountObj.GetComponent<TextMeshProUGUI>().SetText("");

            //Don't let the slot be selected
            this.transform.GetChild(4).gameObject.SetActive(false);
        }
    }

    public void Deselect()
    {
        this.transform.GetChild(4).gameObject.SetActive(false);
    }

    //Selection of a slot
    public void OnPointerDown(PointerEventData eventData)
    {
        //Play sound
        invSound.PlayInventorySound();
        //Deselect previously selected slot
        if (Global.slotSelected != this.slotNumber)
        {
            if (Global.slotSelected == 3)
            {
                this.transform.parent.GetChild(Global.slotSelected).GetComponent<Water>().Deselect();
            }
            else if (Global.slotSelected != -1)
            {
                this.transform.parent.GetChild(Global.slotSelected).GetComponent<Slot>().Deselect();
            }

            //Set this slot active
            if (this.amount > 0)
            {
                this.transform.GetChild(4).gameObject.SetActive(true);
                Global.slotSelected = this.slotNumber;
            }

        }
        //Deselect all slots
        else
        {
            this.Deselect();
            Global.slotSelected = -1;
        }
    }

    public void OnPointerEnter(PointerEventData eventdata)
    {
        //Introduce second type of crop at season 6
        if (Global.season <= 3)
        {
            if (this.slotNumber <=2)
            {
                EnterHover();
            }
        }

        else if(Global.season <= 6)
        {
            if(this.slotNumber <= 2 || (this.slotNumber <= 5 && !UnlockCrop.islock))
            {
                EnterHover();
            }
        }

        //Introduce last type of crop at season 9
        else if (Global.season <= 9)
        {
            if (this.slotNumber <= 2)
            {
                EnterHover();
            }
            else if (this.slotNumber <= 5 && !UnlockCrop.islock)
            {
                EnterHover();
            }
            else if (this.slotNumber > 5 && this.slotNumber <= 7 && !UnlockCrop2.islock2)
            {
                EnterHover();
            }
        }

        //Introduce fertilizer at season 10
        else if (Global.season < 20)
        {
            if (this.slotNumber <= 2 || this.slotNumber == 8)
            {
                EnterHover();
            }
            else if (this.slotNumber <= 5 && !UnlockCrop.islock)
            {
                EnterHover();
            }
            else if (this.slotNumber > 5 && this.slotNumber <= 7 && !UnlockCrop2.islock2)
            {
                EnterHover();
            }
        }

        //Introduce pesticide at season 20
        else if (Global.season >=20)
        {
            if (this.slotNumber <= 2 || this.slotNumber == 8 || this.slotNumber == 9)
            {
                EnterHover();
            }
            else if (this.slotNumber <= 5 && !UnlockCrop.islock)
            {
                EnterHover();
            }
            else if (this.slotNumber <= 7 && !UnlockCrop2.islock2)
            {
                EnterHover();
            }
        }
    }

    public void OnPointerExit(PointerEventData eventdata)
    {
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(2).gameObject.SetActive(true);
        this.transform.GetChild(3).gameObject.SetActive(true);
        this.transform.GetChild(5).gameObject.SetActive(false);
        this.transform.GetChild(6).gameObject.SetActive(false);
    }


    private void EnterHover()
    {
        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(3).gameObject.SetActive(false);
        this.transform.GetChild(5).gameObject.SetActive(true);
        this.transform.GetChild(6).gameObject.SetActive(true);
    }

}
