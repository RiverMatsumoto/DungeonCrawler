using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public BattleSystem battleSystem;
    public void selectTarget()
    {
        // EntitySelectSystem.instance.selectEntity(new AttackCommand());
        battleSystem.EnemyAttacked();
    }
    public void attackCommand()
    {
        
    }
}