using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public List<BattleEntity> allBattleEntites;
    // public List<BattleEntity> party;
    // public List<BattleEntity> enemies;
    public BattleEntityParty party;
    public BattleEntityParty enemies;
    public const int maxPartySize = 5;
    public const int maxEnemyPartySize = 7;
    public int partySize;
    public int enemyPartySize;
    public List<TurnCommand> turnCommands;
    bool playerTurn;

    public BattleEntity currentPlayer;

    public void startBattle()
    {
        //this.enemies = ;  // Choose a random group of enemies
        // Enable the ui that lets you choose actions
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

    public void AddIntendedAction(TurnCommand turnCommand, BattleEntity battleEntity)
    {
        // TODO Add the turn command to the turnCommand list and check that the turn is over
        

    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        EncounterSystem.enterBattle += startBattle;
    }

    private void OnDisable()
    {
        EncounterSystem.enterBattle -= startBattle;
    }
}
