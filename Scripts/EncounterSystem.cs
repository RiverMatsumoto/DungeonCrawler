using UnityEngine;
using Sirenix.OdinInspector;

public class EncounterSystem : MonoBehaviour
{
    public static EncounterSystem instance;
    public OverworldData overworldData;
    public StepCounter stepCounter;


    [Button]
    public void encounterStep()
    {
        overworldData.currentSteps++;
        updateStepCounter();

        if (overworldData.currentSteps >= overworldData.encounterSteps)
        {
            encounteredBattle();
        }
    }

    private void encounteredBattle()
    {
        // TODO Make playermovement class broadcast an event that it landed on a tile with a FOE
        overworldData.inBattle = true;
        overworldData.currentSteps = 0;
        randomizeEncounterSteps();
        BattleEventHandler.broadcastBattleStarted();
    }

    private void updateStepCounter()
    {
        if (stepCounter == null)
        {
            Debug.LogError("Step counter is null in encounter system");
            return;
        }
        stepCounter.updateStepCounter();
    }

    private void randomizeEncounterSteps()
    {
        overworldData.encounterSteps = Random.Range(7, 15);
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
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        MovementEventHandler.playerMoveEnded += encounterStep;
    }

    private void OnDisable()
    {
        MovementEventHandler.playerMoveEnded -= encounterStep;
    }
}
