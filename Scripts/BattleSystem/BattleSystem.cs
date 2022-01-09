using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum BattleOutcome { WON, LOST, ESCAPED }
public class BattleSystem : SerializedMonoBehaviour
{
    public static BattleSystem instance;
    public GameEvent leaveBattleEvent;
    public GameEvent startTurnEvent;
    public GameEvent startBattlePhaseEvent;
    public BattleEntityFactory entityFactory;
    public EntityPartyFactory partyFactory;
    public BattleEntityParty party;
    public BattleEntityParty enemies;
    public BattleEntity currentPlayer;
    public Stack<BattleCommand> intendedCommands;
    public OverworldData overworldData;
    public ChooseRandomEncounter chooseRandomEncounter;
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

    public void startBattle()
    {
        // assign the enemies
        enemies = partyFactory.createBattleEntityParty(EntityPartyType.B1_1);
        addPartyAsChildren();
        //adjust the enemy position
        adjustEnemyPosition();
    }

    public void leaveBattle()
    {
        overworldData.inBattle = false;
        enemies = null;
        leaveBattleEvent.raise();
    }

    public void setEnemyParty(BattleEntityParty enemyParty)
    {
        enemies = enemyParty;
    }

    public void addPartyAsChildren()
    {
        for (var i = 0; i < enemies.party.Length; i++)
        {
            BattleEntity entity = enemies.getBattleEntity(i);
            if (entity == null)
            {
                continue;
            }
            entity.transform.SetParent(this.transform);
        }
    }


    // adjusts the enemies position based on how many enemies in each row there are
    private void adjustEnemyPosition()
    {
        // just a math problem similar to how many slices of pizza you need to cut so everyone gets an equal amount
        const float FRONT_ROW_OFFSET = 10F;
        const float BACK_ROW_OFFSET = 16F;
        const float PLACEMENT_RANGE = 16F;
        
        // float frontRowSpacing = FRONT_ROW_SPACING / enemies.numFrontRow;
        // float backRowSpacing = BACK_ROW_SPACING / enemies.numBackRow;
        float frontRowSpacing = PLACEMENT_RANGE / (enemies.numFrontRow + 1);
        float backRowSpacing = PLACEMENT_RANGE / (enemies.numBackRow + 1);
        float frontRowPlacement = frontRowSpacing;
        float backRowPlacement = backRowSpacing;
        int frontRowCounter = 1;
        int backRowCounter = 1;
        Vector3 frontRowPlacingStart = new Vector3(-8, 1, FRONT_ROW_OFFSET);
        Vector3 backRowPlacingStart = new Vector3(-7, 1, BACK_ROW_OFFSET);
        //adjust front row enemies

        
        for (var i = 0; i < enemies.party.Length; i++)
        {
            BattleEntity entity = enemies.getBattleEntity(i);
            if (entity == null)
            {
                continue;
            }
            if (entity.isBackRow)
            {
                // set the tranform
                entity.transform.localPosition = backRowPlacingStart + new Vector3(backRowCounter++ * frontRowSpacing, 0, 0);
            }
            if (!entity.isBackRow)
            {
                entity.transform.localPosition = frontRowPlacingStart + new Vector3(frontRowCounter++ * frontRowSpacing, 0, 0);
            }
        }
    }

    private void Start()
    {
        overworldData.inBattle = false;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
