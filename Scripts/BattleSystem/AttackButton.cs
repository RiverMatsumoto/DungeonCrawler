using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public SelectorIcon selectorIcon;
    public BattleSystem battleSystem;

    public void selectTarget()
    {
        selectorIcon.enabled = true;
    }
    public void attackCommand()
    {
        
    }
}
