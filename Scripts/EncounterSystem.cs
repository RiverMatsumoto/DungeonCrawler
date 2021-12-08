using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterSystem : MonoBehaviour
{
    public int encounterSteps;
    public int currentSteps;
    public OverworldData overworldData;
    public delegate void enterBattleEvent();
    public static event enterBattleEvent enterBattle;
    public delegate void leaveBattleEvent();
    public static event leaveBattleEvent leftBattle;


    public void encounterStep()
    {
        currentSteps++;

        if (currentSteps >= encounterSteps)
        {
            encounterBattle();
        }
    }

    private void encounterBattle()
    {
        // TODO Make playermovement class broadcast an event that it landed on a tile with a FOE
        currentSteps = 0;
        enterBattle();
        overworldData.inBattle = true;
    }

    public void leaveBattle()
    {
        leftBattle();
        overworldData.inBattle = false;
    }

    private void Start()
    {
        encounterSteps = 10;
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
