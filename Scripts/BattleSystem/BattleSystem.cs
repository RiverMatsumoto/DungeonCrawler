using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum BattleOutcome { WON, LOST, ESCAPED }
public class BattleSystem : SerializedMonoBehaviour, ISelectListener
{
    public static BattleSystem Instance { get; private set; }
    public BattleEntityFactory entityFactory;
    public EntityPartyFactory partyFactory;
    public BattleEntity currentEntity;
    public BattleEntityParty playerParty;
    public BattleEntityParty enemyParty;
    public Stack<BattleCommand> intendedCommands;
    public OverworldData overworldData;
    public ChooseRandomEncounter chooseRandomEncounter;
    public Camera battleCamera;
    public Canvas entityUI;
    public BattleUI battleUI;
    public PartyIterator partyIter;
    public CommandAnimation commandAnimation;


    public void startTurn()
    {
        // TODO setup ui display and let that ui add the intended actions
        partyIter = new PartyIterator(playerParty.party);
        nextPlayer();
    }

    public void startBattlePhase()
    {
        Debug.Log("Started battle phase");
        intendedCommands.Pop().execute();
        // TODO everything in thise phase
        // calculate the order of each command.
        // Call each command and execute() while player hasn't won or lost
        // enable intended action phase again
    }

    public void AddIntendedBattleCommand(BattleCommand battleCommand)
    {
        // TODO Add the turn command to the battleCommand list and check that the turn is over
        intendedCommands.Push(battleCommand);
    }

    public void startBattle()
    {
        overworldData.inBattle = true;
        // assign the enemies
        entityUI.gameObject.SetActive(true);
        enemyParty = partyFactory.createEnemyParty(EntityPartyType.B1_1);
        // playerParty.showParty();
        setPartyParents();
        //adjust the position of the characters
        // adjustEnemyUI();
        // adjustPlayerUI();
        startTurn();
    }

    public void leaveBattle()
    {
        overworldData.inBattle = false;
        enemyParty.clearParty();
        entityUI.gameObject.SetActive(false);
        BattleEventHandler.broadcastBattleEnded();
    }

    public void setEnemyParty(BattleEntityParty enemyParty)
    {
        this.enemyParty = enemyParty;
    }

    public void setPartyParents()
    {
        if (playerParty != null) 
        {
            GameObject party = entityUI.transform.GetChild(1).gameObject;
            GameObject frontRow = party.transform.GetChild(0).gameObject;
            GameObject backRow = party.transform.GetChild(1).gameObject;
            PartyIterator iterator = new PartyIterator(playerParty.party);
            while (iterator.HasNext())
            {
                BattleEntity entity = iterator.Next();
                if (entity.isBackRow)
                    entity.transform.SetParent(backRow.transform, false); 
                else
                    entity.transform.SetParent(frontRow.transform, false); 
                
            }
        }
        if (enemyParty != null)
        {
            GameObject party = entityUI.transform.GetChild(0).gameObject;
            GameObject frontRow = party.transform.GetChild(0).gameObject;
            GameObject backRow = party.transform.GetChild(1).gameObject;
            PartyIterator iterator = new PartyIterator(enemyParty.party);
            while (iterator.HasNext())
            {
                BattleEntity entity = iterator.Next();
                if (entity.isBackRow)
                    entity.transform.SetParent(backRow.transform); 
                else
                    entity.transform.SetParent(frontRow.transform); 
                
            }
        }
    }

    public void EnemyAttacked()
    {
        enemyParty.getBattleEntity(0).characterData.Health -= 10;
    }

    private void adjustPlayerUI()
    {
        const float BACK_ROW_VERTICAL_OFFSET = -475F;
        const float FRONT_ROW_VERTICAL_OFFSET = -355F;
        float PLACEMENT_RANGE = 1500F;
        float frontXStart = (PLACEMENT_RANGE / (playerParty.numFrontRow + 1)) - 1000;
        float backXStart = (PLACEMENT_RANGE / (playerParty.numBackRow + 1)) - 1000;
        float playerSpacing = 265F;
        int frontCounter = 1;
        int backCounter = 1;
        Vector3 backRowPlacingStart = new Vector3(backXStart, BACK_ROW_VERTICAL_OFFSET, 0);
        Vector3 frontRowPlacingStart = new Vector3(frontXStart, FRONT_ROW_VERTICAL_OFFSET, 0);
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
    private void adjustEnemyUI()
    {
        // just a math problem similar to how many slices of pizza you need to cut so everyone gets an equal amount
        // TODO TRY REPLACE THIS SOLUTION WITH THE PLAYER SOLUTION
        const float BACK_ROW_VERTICAL_OFFSET = 50F;
        const float FRONT_ROW_VERTICAL_OFFSET = -140F;
        float PLACEMENT_RANGE = 1500F;
        float frontXStart = (PLACEMENT_RANGE / (playerParty.numFrontRow + 1)) - 1000;
        float backXStart = (PLACEMENT_RANGE / (playerParty.numBackRow + 1)) - 1000;
        float enemySpacing = 240F;
        int frontCounter = 1;
        int backCounter = 1;
        Vector3 backRowPlacingStart = new Vector3(backXStart, BACK_ROW_VERTICAL_OFFSET, 0);
        Vector3 frontRowPlacingStart = new Vector3(frontXStart, FRONT_ROW_VERTICAL_OFFSET, 0);
        for (var i = 0; i < enemyParty.partyCapacity; i++)
        {
            BattleEntity entity = enemyParty.getBattleEntity(i);
            if (entity == null) continue;
            if (entity.isBackRow)
            {
                // set the tranform
                entity.transform.localPosition = backRowPlacingStart + new Vector3(backCounter++ * enemySpacing, 0, 0);
            }
            if (!entity.isBackRow)
            {
                entity.transform.localPosition = frontRowPlacingStart + new Vector3(frontCounter++ * enemySpacing, 0, 0);
            }
        }
    }

    public void nextPlayer()
    {
        if (partyIter.HasNext())
        {
            if (currentEntity != null)
                currentEntity.setHighlight(false);
            currentEntity = partyIter.Next();
            currentEntity.setHighlight(true);
        }
    }

    public void prevPlayer()
    {
        Debug.Log("has prev: " + partyIter.HasPrev());
        if (partyIter.HasPrev())
        {
            if (currentEntity != null)
                currentEntity.setHighlight(false);
            currentEntity = partyIter.Prev();
            currentEntity.setHighlight(true);
        }
    }

    #region BattleEntity selecting system
    /// <summary>
    /// Starts selecting an entity on the battlefield
    /// </summary>
    /// <param name="defaultToEnemy">True if the default selecting should be an enemy, false if party</param>
    public void StartSelectingEntity(bool defaultToEnemy)
    {
        // Enable the buttons on battle entities and put selector on on of them
        ListenToSelectPlayer();
        PlayerSelectSystem.Instance.StartSelectPlayer();
        PartyIterator temp;
        if (defaultToEnemy)
            temp = new PartyIterator(enemyParty.party);
        else
            temp = new PartyIterator(playerParty.party);
        temp.Next().button.Select();
    }

    public void OnSelectPlayerCancel()
    {
        StopListeningToSelectPlayer();
    }

    public void ListenToSelectPlayer()
    {
        EnableSelecting();
        PlayerSelectSystem.Instance._cancelSelectPlayer += OnSelectPlayerCancel;
        PlayerSelectSystem.Instance._selectPlayer += OnSelectPlayer;
    }

    public void StopListeningToSelectPlayer()
    {
        DisableSelecting();
        PlayerSelectSystem.Instance._cancelSelectPlayer -= OnSelectPlayerCancel;
        PlayerSelectSystem.Instance._selectPlayer -= OnSelectPlayer;
    }

    public void OnSelectPlayer(BattleEntity entity)
    {
        // Next character's turn to choose their intended action, otherwise start battle phase
        if (partyIter.HasNext())
            nextPlayer();
        else
        {
            Debug.Log("Should start the next turn since reached last player in party");
            startBattlePhase();
        }
        OnSelectPlayerCancel();
    }

    private void EnableSelecting()
    {
        enemyParty.EnableSelecting();
        playerParty.EnableSelecting();
    }

    private void DisableSelecting()
    {
        enemyParty.DisableSelecting();
        playerParty.DisableSelecting();
    }
    #endregion

    public void OnCancel()
    {
        if (!overworldData.inBattle)
            return;
        
        if (PlayerSelectSystem.isSelecting)
            DefaultMenu();
        else if (intendedCommands.Count > 0)
        {
            Debug.Log($"Intended commands size: {intendedCommands.Count}");
            intendedCommands.Pop();
            prevPlayer();
        }

    }

    public void DefaultMenu()
    {
        Debug.Log("Default menu OnCancel");
        PlayerSelectSystem.Instance.SelectPlayerCancel();
        battleUI.stopSelectingEntity();
        // Possibly other submenus to change
    }

    public void AnimateCommand(string animation, BattleEntity target)
    {
        commandAnimation.PlayAnimation(animation, target);
    }

    private void Start()
    {
        overworldData.inBattle = false;
        playerParty = partyFactory.createPlayerParty();
        enemyParty = null;
        setPartyParents();
        adjustPlayerUI();
        entityUI.gameObject.SetActive(false);
        intendedCommands = new Stack<BattleCommand>();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this) 
            Destroy(this);
        else 
            Instance = this;
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