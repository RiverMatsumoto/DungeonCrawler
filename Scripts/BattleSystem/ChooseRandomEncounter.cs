using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomEncounter : MonoBehaviour
{
    // TODO VERY TEMPORARY SOLUTION TO CHOOSE AN ENCOUNTER, WILL CHANGE LATER. 
    // TODO Probably inherit classes and choose enemies based on floor.
    static BattleEntity[] enemies;
    static OverworldData overworldData;
    static List<CharacterData> enemyData;

    public static BattleEntity[] chooseRandomEncounter()
    {
        int numEnemies = Random.Range(1, 3);
        for (var i = 0; i < numEnemies; i++)
        {
            enemies[i].characterData = enemyData[Random.Range(0,2)];
        }
        return enemies;
    }
}
