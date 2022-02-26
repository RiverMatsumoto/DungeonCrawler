using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "EntityPartyFactory", menuName = "ScriptableObject/EntityPartyFactory")]
public class EntityPartyFactory : SerializedScriptableObject
{
    public CharacterDataProvider dataProvider;
    public BattleEntityFactory entityFactory;
    private const int MAX_PARTY_MEMBERS = BattleEntityParty.MAX_PARTY_MEMBERS;

    // Uses the battleEntity factory to create new battle entities and add them to the party.
    public BattleEntityParty createEnemyParty(EntityPartyType type)
    {
        PartyDataStruct data = dataProvider.getEntityPartyFor(type);
        BattleEntity[] battleEntities = new BattleEntity[6];
        BattleEntityParty enemyParty = new BattleEntityParty(true, type);
        // populate battle entity array with enemies
        for (int i = 0; i < data.party.Length; i++)
        {
            if (data.party[i].enemyType == EnemyType.Null)
            {
                battleEntities[i] = null;
            }
            else
            {
                battleEntities[i] = entityFactory.createEnemy(data.party[i].enemyType);
                battleEntities[i].name = "Enemy " + i;
            }
            // use the array to add the enemies to the party
            if (battleEntities[i] != null)
            {
                enemyParty.addBattleEntity(battleEntities[i], i);
            }
        }
        return enemyParty;
    }

    //TODO Later when making the party builder, I need to add paramters where that party builder does all the work
    public BattleEntityParty createPlayerParty()
    {
        // TODO MAKE MORE ROBUST SEARCH SYSTEM. FIGURE OUT THE DATA STRUCTURE OR SYSTEM FOR STORING AND ACCESSING PLAYERS
        BattleEntity[] playerEntities = new BattleEntity[MAX_PARTY_MEMBERS];
        BattleEntityParty playerParty = new BattleEntityParty(true, EntityPartyType.Player);
        playerEntities[0] = entityFactory.createPlayer(dataProvider.getPartyMemberData("Johnny"));
        playerEntities[1] = entityFactory.createPlayer(dataProvider.getPartyMemberData("Jotaro"));
        playerEntities[2] = entityFactory.createPlayer(dataProvider.getPartyMemberData("Joseph"));
        playerEntities[3] = entityFactory.createPlayer(dataProvider.getPartyMemberData("Josuke"));
        playerEntities[4] = entityFactory.createPlayer(dataProvider.getPartyMemberData("Jolyne"));
        for (var i = 0; i < MAX_PARTY_MEMBERS; i++)
        {
            if (playerEntities[i] != null)
            {
                playerParty.addBattleEntity(playerEntities[i], i);
            }
        }
        return playerParty;
    }
}
