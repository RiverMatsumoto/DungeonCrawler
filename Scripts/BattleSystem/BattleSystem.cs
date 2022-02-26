using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum BattleOutcome { WON, LOST, ESCAPED }
public class BattleSystem : SerializedMonoBehaviour
{
    public BattleEntityFactory entityFactory;
    public EntityPartyFactory partyFactory;
    public BattleEntityParty playerParty;
    public BattleEntityParty enemyParty;
    public BattleEntity currentPlayer;
    public Stack<BattleCommand> intendedCommands;
    public OverworldData overworldData;
    public ChooseRandomEncounter chooseRandomEncounter;
    public Camera battleCamera;
    public Canvas playerUI;
    public int partySize;
    public int enemyPartySize;
    private bool playerTurn;


    public void startTurn()
    {
        // TODO setup ui display and let that ui add the intended actions
    }

    public void startBattlePhase()
    {
        // startBattlePhaseEvent.raise();
        BattleEventHandler.broadcastBattleStarted();
    }

    public void AddIntendedBattleCommand(BattleCommand battleCommand, BattleEntity battleEntity)
    {
        // TODO Add the turn command to the battleCommand list and check that the turn is over
        intendedCommands.Push(battleCommand);
        
    }

    public void startBattle()
    {
        // assign the enemies
        enemyParty = partyFactory.createEnemyParty(EntityPartyType.B1_1);
        playerParty = partyFactory.createPlayerParty();
        addPartiesAsChildren();
        //adjust the enemy position
        adjustEnemyPositions();
        // adjustPlayerPositions();
        testAdjustPlayerPositions();
    }

    public void leaveBattle()
    {
        overworldData.inBattle = false;
        enemyParty = null;
        BattleEventHandler.broadcastBattleEnded();
    }

    public void setEnemyParty(BattleEntityParty enemyParty)
    {
        this.enemyParty = enemyParty;
    }

    public void addPartiesAsChildren()
    {
        for (var i = 0; i < enemyParty.partyCapacity; i++)
        {
            BattleEntity entity = enemyParty.getBattleEntity(i);
            if (entity == null)
            {
                continue;
            }
            entity.transform.SetParent(this.transform);
        }
        for (var i = 0; i < playerParty.partyCapacity; i++)
        {
            BattleEntity entity = playerParty.getBattleEntity(i);
            if (entity == null)
            {
                continue;
            }
            entity.transform.SetParent(playerUI.transform);
        }
    }

    public void EnemyAttacked()
    {
        enemyParty.getBattleEntity(0).characterData.health -= 10;
    }

    private void testAdjustPlayerPositions()
    {
        // consts, horizontal spacing is 0.32F for 3 players, -0.16 for 2 players, 0 for 1 Vertical is 0.37F
        const float BACK_ROW_VERTICAL_OFFSET = -0.5F;
        const float FRONT_ROW_VERTICAL_OFFSET = -0.37F;
        float playerSpacing = 0.32F;
        int frontCounter = 0;
        int backCounter = 0;
        Vector3 backRowPlacingStart = new Vector3(-(((playerParty.numBackRow - 1F) / 2F) * playerSpacing), BACK_ROW_VERTICAL_OFFSET, 1F);
        Vector3 frontRowPlacingStart = new Vector3(-(((playerParty.numFrontRow - 1F) / 2F) * playerSpacing), FRONT_ROW_VERTICAL_OFFSET, 1F);
        for (int i = 0; i < playerParty.partyCapacity; i++)
        {
            BattleEntity entity = playerParty.getBattleEntity(i);
            if (entity == null) continue;
            if (entity.isBackRow)
            {
                entity.transform.localPosition = backRowPlacingStart + new Vector3(backCounter++ * playerSpacing, 0, 0);
            }
            else
            {
                entity.transform.localPosition = frontRowPlacingStart + new Vector3(frontCounter++ * playerSpacing, 0, 0);
            }
        }
    }

    private void adjustPlayerPositions()
    {
        // consts, horizontal spacing is 0.32F for 3 players, -0.16 for 2 players, 0 for 1 Vertical is 0.37F
        const float BACK_ROW_VERTICAL_OFFSET = -0.5F;
        const float FRONT_ROW_VERTICAL_OFFSET = -0.37F;
        float playerSpacing = 0.32F;
        int frontCounter = 0;
        int backCounter = 0;
        Vector3 backRowPlacingStart = new Vector3(-(((playerParty.numBackRow - 1F) / 2F) * playerSpacing), BACK_ROW_VERTICAL_OFFSET, 1F);
        Vector3 frontRowPlacingStart = new Vector3(-(((playerParty.numFrontRow - 1F) / 2F) * playerSpacing), FRONT_ROW_VERTICAL_OFFSET, 1F);
        for (int i = 0; i < playerParty.partyCapacity; i++)
        {
            BattleEntity entity = playerParty.getBattleEntity(i);
            if (entity == null) continue;
            if (entity.isBackRow)
            {
                entity.transform.localPosition = backRowPlacingStart + new Vector3(backCounter++ * playerSpacing, 0, 0);
            }
            else
            {
                entity.transform.localPosition = frontRowPlacingStart + new Vector3(frontCounter++ * playerSpacing, 0, 0);
            }
        }

    }


    // adjusts the enemies position based on how many enemies in each row there are
    private void adjustEnemyPositions()
    {
        // just a math problem similar to how many slices of pizza you need to cut so everyone gets an equal amount
        // TODO TRY REPLACE THIS SOLUTION WITH THE PLAYER SOLUTION
        const float FRONT_ROW_OFFSET = 10F;
        const float BACK_ROW_OFFSET = 15F;
        const float PLACEMENT_RANGE = 16F;

        float frontRowSpacing = PLACEMENT_RANGE / (enemyParty.numFrontRow + 1);
        float backRowSpacing = PLACEMENT_RANGE / (enemyParty.numBackRow + 1);
        int frontRowCounter = 1;
        int backRowCounter = 1;
        // Where the start of the placing range is.
        Vector3 frontRowPlacingStart = new Vector3(-8, 1, FRONT_ROW_OFFSET);
        Vector3 backRowPlacingStart = new Vector3(-6, 1, BACK_ROW_OFFSET);

        for (var i = 0; i < enemyParty.partyCapacity; i++)
        {
            BattleEntity entity = enemyParty.getBattleEntity(i);
            if (entity == null) continue;
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

    private void OnEnable()
    {
        BattleEventHandler.battleStarted += startBattle;
    }

    private void OnDisable()
    {
        BattleEventHandler.battleStarted -= startBattle;
    }
}
