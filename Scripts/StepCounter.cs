using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class StepCounter : MonoBehaviour
{
    public TMP_Text stepCounterText;

    // Doesn't actually use position in this case. Functionality may change later
    public void updateStepCounter()
    {
        stepCounterText.text = "Steps: " + EncounterSystem.instance.currentSteps.ToString() 
            + "\nEncounter in: " + EncounterSystem.instance.encounterSteps;
    }

    private void OnEnable()
    {
        MovementEventHandler.broadcastPlayerMoveEnded += updateStepCounter;
    }

    private void OnDisable()
    {
        MovementEventHandler.broadcastPlayerMoveEnded -= updateStepCounter;
    }
}
