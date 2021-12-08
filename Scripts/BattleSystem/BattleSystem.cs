using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleEntity[] allBattleEntites;
    public BattleEntity[] party;
    public BattleEntity[] enemies;
    public const int maxPartySize = 5;
    public const int maxEnemyPartySize = 7;
    public int partySize;
    public int enemyPartySize;
    public List<TurnCommand> turnCommands;
    bool playerTurn;
    

    public void startBattle(BattleEntity[] enemies)
    {
        this.enemies = enemies;
    }

    public void endBattle()
    {

    }

    public void startTurn()
    {
        // TODO setup ui display and let that ui add the intended actions
    }

    public void endTurn()
    {

    }

    public void AddIntendedAction()
    {
        // TODO Add the turn command to the turnCommand list and check that the turn is over
    }

    private void Start()
    {
        party = new BattleEntity[maxPartySize];
        enemies = new BattleEntity[maxEnemyPartySize];
        allBattleEntites = new BattleEntity[maxEnemyPartySize + maxPartySize];
    }
}
