using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCamera : MonoBehaviour
{
    private void disableCamera()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<AudioListener>().enabled = false;
    }

    private void enableCamera()
    {
        GetComponent<Camera>().enabled = true;
        GetComponent<AudioListener>().enabled = true;
    }

    private void OnEnable()
    {
        EncounterSystem.enterBattle += disableCamera;
        EncounterSystem.leftBattle += enableCamera;
    }

    private void OnDisable()
    {
        EncounterSystem.enterBattle -= disableCamera;
        EncounterSystem.leftBattle -= enableCamera;
    }
}
