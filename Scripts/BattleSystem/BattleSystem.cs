using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleOutcome { WON, LOST, ESCAPED }
public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;
    public delegate void enterBattleEvent();
    public static event enterBattleEvent broadcastEnterBattle;
    public delegate void leaveBattleEvent();
    public static event leaveBattleEvent broadcastLeaveBattle;
    public delegate void startTurnEvent();
    public static event startTurnEvent broadcastStartTurn;
    public delegate void startBattlePhaseEvent();
    public static event startBattlePhaseEvent broadcastStartBattlePhase;
    public List<BattleEntity> allBattleEntites;
    public BattleEntityParty party;
    public BattleEntityParty enemies;
    public BattleEntity currentPlayer;
    public List<BattleCommand> battleCommands;
    public Stack<BattleCommand> intendedCommands;
    public int partySize;
    public int enemyPartySize;
    bool playerTurn;


    public void startTurn()
    {
        // TODO setup ui display and let that ui add the intended actions
        broadcastStartTurn();
    }

    public void startBattlePhase()
    {
        broadcastStartBattlePhase();
    }

    public void AddIntendedBattleCommand(BattleCommand battleCommand, BattleEntity battleEntity)
    {
        // TODO Add the turn command to the battleCommand list and check that the turn is over
        intendedCommands.Push(battleCommand);

    }

    public static void enterBattle()
    {
        broadcastEnterBattle();
    }

    public static void leaveBattle()
    {
        broadcastLeaveBattle();
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
