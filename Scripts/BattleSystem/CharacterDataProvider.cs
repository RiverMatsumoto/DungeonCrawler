using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CharacterDataProvider", menuName = "ScriptableObject/CharacterDataProvider")]
public class CharacterDataProvider : SerializedScriptableObject
{
    public Dictionary<EnemyType, CharacterData> dataLibrary;
    public Dictionary<EntityPartyType, PartyDataStruct> entityPartyLibrary;
    public Dictionary<ClassTypeEnum, ClassType> classLibrary;

    public CharacterData getEntityDataFor(EnemyType type)
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
}

public enum EnemyType
{
    Null,
    Groundhog,
    Ladybug
}

public enum EntityPartyType
{
    B1_1,
    B1_2,
    B2_1
}
