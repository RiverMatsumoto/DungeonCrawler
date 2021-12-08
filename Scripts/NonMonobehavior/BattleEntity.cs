using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleEntity
{
    public CharacterData characterData { get; set; }
    public float[] damageMultipliers { get; set; }
    public float[] speedMultipliers { get; set; }
    

    
    public virtual void attack()
    {
        
    }
}
