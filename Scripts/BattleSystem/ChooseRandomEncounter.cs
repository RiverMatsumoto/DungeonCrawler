using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomEncounter : MonoBehaviour
{
    // TODO VERY TEMPORARY SOLUTION TO CHOOSE AN ENCOUNTER, WILL CHANGE LATER. 
    // TODO Probably have a current possible enemies and add certain enemies based on position
    static List<BattleEntity> enemyList;
    static List<BattleEntity> currentRandomEncounter;
    static OverworldData overworldData;
    static List<CharacterData> enemyData;
    const int maxEnemies = 6;


    // random number of enemies and random enemies
    public static BattleEntity[] chooseRandomEncounter()
    {
        int numEnemies = Random.Range(1, 3);
        BattleEntity[] enemiesEncountered = new BattleEntity[maxEnemies];
        for (var i = 0; i < numEnemies; i++)
        {
            // doesn't account for enemy groups at specific floors and parts of the floor
            enemyList[i].characterData = enemyData[Random.Range(0, enemyList.Capacity)];
            enemiesEncountered[i] = enemyList[i];
        }
        return enemiesEncountered;
    }

}
