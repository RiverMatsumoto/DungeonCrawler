using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleEntity : MonoBehaviour
{
    public CharacterData characterData;
    public float[] damageMultipliers;
    public float[] speedMultipliers;
    public TurnCommand turnCommand;
    public bool isBackRow;
    public int partyPosition 
    {
        get
        {
            return partyPosition;
        }
        set
        {
            if (partyPosition <= 3)
            {
                isBackRow = true;
            }
            partyPosition = value;
        }
    }
    

    
    public virtual void attack()
    {
        Debug.Log("attacked something lol");
    }


}
