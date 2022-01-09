using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldDataHandler : MonoBehaviour
{
    // updates the overworlddata scriptable object 
    public OverworldData overworldData;
    public PlayerMovement playerMovement;
    public EncounterSystem encounterSystem;

    private void Start()
    {
        overworldData.inBattle = false;
    }

    public void updatePlayerPosition()
    {
        overworldData.playerPosition = playerMovement.mapPosition;
    }

    public void updatePlayerFacing()
    {
        overworldData.playerFacingDir = playerMovement.localForward;
    }

    public void updateStepCounter()
    {
        overworldData.currentSteps++;
    }
}
