//Create a UI element by going to Create >UI and choose one of the visible items(Image, Button, Panel etc.) from the list. This script gives the GameObject a Button-like behaviour.
//Attach this script to the UI GameObject

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOnSubmit : Button
{
    //Press enter on the Button GameObject to trigger this Event
    public override void OnSubmit(BaseEventData eventData)
    {
        //Output that the Button is in the submit stage
        Debug.Log("Submitted!");
    }
}