using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CharacterDataProvider", menuName = "ScriptableObject/CharacterDataProvider")]
public class CharacterDataProvider : SerializedScriptableObject
{
    [PropertySpace(16)]
    public Dictionary<EnemyType, CharacterDataEditor> dataLibrary;
    [PropertySpace(16)]
    public Dictionary<EntityPartyType, PartyDataStruct> entityPartyLibrary;
    [PropertySpace(16)]
    public Dictionary<ClassTypeEnum, ClassType> classLibrary;
    [PropertySpace(16)]
    public List<CharacterDataEditor> playerEntityLibrary;
    [PropertySpace(16)]
    public BattleEntityParty currentPlayerParty;
    public CharacterDataEditor getEntityDataFor(EnemyType type)
    {
        return dataLibrary[type];
    }
    
    public PartyDataStruct getEntityPartyFor(EntityPartyType type)
    {
        return entityPartyLibrary[type];
    }

    public ClassType getClassTypeFor(ClassTypeEnum type)
    {
        return classLibrary[type];
    }

    public CharacterDataEditor getPartyMemberData(string charName)
    {
        CharacterDataEditor character = playerEntityLibrary.Find(s => s.characterName == charName);
        if (character == null)
        {
            Debug.LogError("Couldn't find character with name: " + charName);
            return null;
        }
        return character;
    }
}

public enum EnemyType
{
    Null,
    Player,
    Groundhog,
    Ladybug,
    Mantis
}

public enum EntityPartyType
{
    Player,
    B1_1,
    B1_2,
    B2_1
}
