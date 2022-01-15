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
    public BattleEntityParty createEnemyParty(EntityPartyType type)
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
                battleEntities[i] = entityFactory.createEnemy(data.party[i].enemyType);
                if (data.party[i].isBackRow)
                {
                    battleEntities[i].isBackRow = true;
                }
                battleEntities[i].name = "Enemy " + (i + 1);
            }
        }

        BattleEntityParty enemyParty = new BattleEntityParty(battleEntities, true, type);
        return enemyParty;
    }

    public BattleEntityParty createPlayerParty()
    {
        // TODO MAKE MORE ROBUST SEARCH SYSTEM. FIGURE OUT THE DATA STRUCTURE OR SYSTEM FOR STORING AND ACCESSING PLAYERS
        BattleEntity[] playerEntities = new BattleEntity[6];
        playerEntities[0] = entityFactory.createPlayer(dataProvider.playerEntityLibrary.Find(entity => entity.characterName == "Johnny"));
        playerEntities[1] = entityFactory.createPlayer(dataProvider.playerEntityLibrary.Find(entity => entity.characterName == "Johnny"));
        playerEntities[2] = entityFactory.createPlayer(dataProvider.playerEntityLibrary.Find(entity => entity.characterName == "Johnny"));
        playerEntities[3] = entityFactory.createPlayer(dataProvider.playerEntityLibrary.Find(entity => entity.characterName == "Johnny"));
        playerEntities[4] = entityFactory.createPlayer(dataProvider.playerEntityLibrary.Find(entity => entity.characterName == "Johnny"));
        playerEntities[2].isBackRow = true;
        playerEntities[3].isBackRow = true;
        playerEntities[4].isBackRow = true;
        BattleEntityParty playerParty = new BattleEntityParty(playerEntities, false);
        return playerParty;
    }
}
