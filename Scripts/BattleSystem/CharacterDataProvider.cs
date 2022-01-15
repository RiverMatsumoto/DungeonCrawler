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
}

public enum EnemyType
{
    Null,
    Groundhog,
    Ladybug,
    Mantis
}

public enum EntityPartyType
{
    B1_1,
    B1_2,
    B2_1
}
