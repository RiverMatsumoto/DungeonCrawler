using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CharacterDataLibrary", menuName = "ScriptableObject/CharacterDataLibrary", order = 6)]
public class CharacterDataLibrary : SerializedScriptableObject
{
    // Could extend the list class and change the Add() method to change the numEntities
    public List<BattleEntity> battleEntityLibrary;
    public List<BattleEntityParty> enemyPartyLibrary;
    public Dictionary<EnemyType, CharacterDataEditor> dataLibrary;

    public CharacterDataEditor getDataFor(EnemyType type)
    {
        return dataLibrary[type];
    }

    public BattleEntityParty getBattleEntityParty(int index)
    {
        BattleEntityParty party = enemyPartyLibrary[index];
        return party;
    }


    public struct CharacterDataStruct
    {
        public CharacterDataStruct(CharacterDataEditor characterData)
        {
            name = characterData.characterName;
        }
        public string name { get; set; }
    }
}
