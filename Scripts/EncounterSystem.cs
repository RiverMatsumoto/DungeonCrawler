using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterSystem : MonoBehaviour
{
    public static EncounterSystem instance;
    public int encounterSteps;
    public int currentSteps;
    public OverworldData overworldData;
    public StepCounter stepCounter;


    public void encounterStep()
    {
        currentSteps++;
        updateStepCounter();

        if (currentSteps >= encounterSteps)
        {
            encounteredBattle();
        }
    }

    public void leaveBattle()
    {
        BattleSystem.leaveBattle();
        overworldData.inBattle = false;
    }

    private void encounteredBattle()
    {
        // TODO Make playermovement class broadcast an event that it landed on a tile with a FOE
        currentSteps = 0;
        randomizeEncounterSteps();
        BattleSystem.enterBattle();
        overworldData.inBattle = true;
    }

    private void updateStepCounter()
    {
        if (stepCounter != null)
        {
            stepCounter.updateStepCounter();
        }
    }

    private void randomizeEncounterSteps()
    {
        encounterSteps = Random.Range(7, 15);
        updateStepCounter();
    }

    private void Start()
    {
        randomizeEncounterSteps();
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

    private void OnEnable()
    {
        MovementEventHandler.broadcastPlayerMoveEnded += encounterStep;
    }

    private void OnDisable()
    {
        MovementEventHandler.broadcastPlayerMoveEnded -= encounterStep;
    }
}
