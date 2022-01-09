using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleOutcome { WON, LOST, ESCAPED }
public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;
    public GameEvent leaveBattleEvent;
    public GameEvent startTurnEvent;
    public GameEvent startBattlePhaseEvent;
    // public delegate void enterBattleEvent();
    // public static event enterBattleEvent broadcastEnterBattle;
    // public delegate void leaveBattleEvent();
    // public static event leaveBattleEvent broadcastLeaveBattle;
    // public delegate void startTurnEvent();
    // public static event startTurnEvent broadcastStartTurn;
    // public delegate void startBattlePhaseEvent();
    // public static event startBattlePhaseEvent broadcastStartBattlePhase;
    public List<BattleEntity> allBattleEntites;
    public BattleEntityParty party;
    public BattleEntityParty enemies;
    public BattleEntity currentPlayer;
    public List<BattleCommand> battleCommands;
    public Stack<BattleCommand> intendedCommands;
    public OverworldData overworldData;
    public int partySize;
    public int enemyPartySize;
    bool playerTurn;


    public void startTurn()
    {
        // TODO setup ui display and let that ui add the intended actions
        startTurnEvent.raise();
    }

    public void startBattlePhase()
    {
        startBattlePhaseEvent.raise();
    }

    public void AddIntendedBattleCommand(BattleCommand battleCommand, BattleEntity battleEntity)
    {
        // TODO Add the turn command to the battleCommand list and check that the turn is over
        intendedCommands.Push(battleCommand);

    }

    public void leaveBattle()
    {
        overworldData.inBattle = false;
        leaveBattleEvent.raise();
    }
    
    public void setEnemyParty(BattleEntityParty enemyParty)
    {
        enemies = enemyParty;
    }

    public void initializeEnemies()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
}
