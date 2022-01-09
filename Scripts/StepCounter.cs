using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class StepCounter : MonoBehaviour
{
    public OverworldData overworldData;
    public TMP_Text stepCounterText;

    // Doesn't actually use position in this case. Functionality may change later
    public void updateStepCounter()
    {
        stepCounterText.text = "Steps: " + overworldData.currentSteps 
            + "\nEncounter in: " + overworldData.encounterSteps;
    }

    private void OnEnable()
    {
        // MovementEventHandler.broadcastPlayerMoveEnded += updateStepCounter;
    }

    private void OnDisable()
    {
        // MovementEventHandler.broadcastPlayerMoveEnded -= updateStepCounter;
    }
}
