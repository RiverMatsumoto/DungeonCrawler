using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleEntity : MonoBehaviour
{
    // TODO add loot table, items, and item system
    public CharacterData characterData;
    public BattleCommand intendedBattleCommand;
    public BattleEntity target;
    public float[] damageMultipliers;
    public float[] speedMultipliers;
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

    public void selectEntity()
    {
        EntitySelectSystem.instance.setTarget(this);
    }

    public void displayStats()
    {
        if (characterData.characterName == "Groundhog")
        {
            Debug.Log(characterData.health);
            characterData.health++;
            Debug.Log(characterData.health);

        }
    }

    public void setCharacterData(CharacterData characterData)
    {
        this.characterData = characterData.getClone(); // required so that 
    }

    private void Start()
    {
        characterData = characterData.getClone();
        displayStats();
    }
}
