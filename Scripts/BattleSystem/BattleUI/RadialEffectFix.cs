using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ButtonManagerBasic))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(EventTrigger))]
public class RadialEffectFix : MonoBehaviour
{
    ButtonManagerBasic buttonManager;
    Button button;

    private void Start() 
    {
        if (buttonManager == null)
        {
            buttonManager = GetComponent<ButtonManagerBasic>();
        }
        if (button == null)
        {
            button = GetComponent<Button>();
        }

        
    }

    public void createRipple()
    {
        buttonManager.CreateRipple(new Vector2(0,0));
    }
}
