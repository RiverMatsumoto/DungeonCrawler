using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "EntityPartyFactory", menuName = "ScriptableObject/EntityPartyFactory")]
public class EntityPartyFactory : SerializedScriptableObject
{
    public CharacterDataProvider dataProvider;
    public BattleEntityFactory entityFactory;

    // Uses the battleEntity factory to create new battle entities and add them to the party.
    public BattleEntityParty createBattleEntityParty(EntityPartyType type)
    {
        PartyDataStruct data = dataProvider.getEntityPartyFor(type);
        BattleEntity[] battleEntities = new BattleEntity[6];
        for (int i = 0; i < data.party.Length; i++)
        {
            if (data.party[i].enemyType == EnemyType.Null)
            {
                battleEntities[i] = null;
            }
            else
            {
                battleEntities[i] = entityFactory.createBattleEntity(data.party[i].enemyType);
                if (data.party[i].isBackRow)
                {
                    battleEntities[i].isBackRow = true;
                }
                battleEntities[i].name = "Enemy " + (i + 1);
            }
        }

        BattleEntityParty newParty = new BattleEntityParty(battleEntities, true, type);
        return newParty;
    }
}
