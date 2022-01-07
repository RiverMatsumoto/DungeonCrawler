using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public void selectTarget()
    {
        EntitySelectSystem.instance.selectEntity(new AttackCommand());
    }
    public void attackCommand()
    {
        
    }
}