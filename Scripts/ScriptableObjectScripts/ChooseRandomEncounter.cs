using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

// This will choose random encounters and inject character data into the battle entities
[CreateAssetMenu(fileName = "ChooseRandomEncounter", menuName = "ScriptableObject/ChooseRandomEncounter")]
public class ChooseRandomEncounter : SerializedScriptableObject
{
    public BattleEntityFactory entityFactory;
    public BattleEntityParty encounteredEnemies;


    public BattleEntityParty chooseRandomEncounter()
    {
        //TODO REDO ALL DATA USING STRUCTS
        return encounteredEnemies;
    }

    public void injectCharacterData(BattleEntity battleEntity)
    {

        // battleEntity.characterData = characterDataLibrary.characterDataLibrary.Find(entity => entity.Equals(battleEntity)).characterData.getClone();
    }
}
