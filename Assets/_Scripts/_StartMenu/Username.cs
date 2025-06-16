using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Username : MonoBehaviour
{
    private TMP_InputField input;
    EventSystem system;

    void Start()
    {
        input = gameObject.GetComponent<TMP_InputField>();
        input.onEndEdit.AddListener(UpdateUser);
        if (Global.tutorial)
        {
            input.text = Global.username;
        }
        system = EventSystem.current;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {

                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null)
                    inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
            //else Debug.Log("next nagivation element not found");

        }
    }

    private void UpdateUser(string arg)
    {
        Global.username = arg;
    }

}
