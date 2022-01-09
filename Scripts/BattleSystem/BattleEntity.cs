using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

[ShowOdinSerializedPropertiesInInspector]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(SpriteRenderer))]
public class BattleEntity : SerializedMonoBehaviour
{
    // TODO add loot table, items, and item system
    public BattleEntityParty party;
    public CharacterDataStruct characterData;
    public BattleCommand intendedBattleCommand;
    public BattleEntity target;
    public List<BattleCommand> learnedSkills;
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

    public void setCharacterData(CharacterData characterData)
    {
        GetComponent<SpriteRenderer>().sprite = characterData.sprite;
        this.characterData = new CharacterDataStruct(characterData);
    }

    // public void setCharacterData(CharacterData characterData)
    // {
        
    // }
}
