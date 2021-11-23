using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour
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
        EncounterSystem.enterBattle += enableCamera;
        EncounterSystem.leftBattle += disableCamera;
    }

    private void OnDisable()
    {
        EncounterSystem.enterBattle -= enableCamera;
        EncounterSystem.leftBattle -= enableCamera;
    }

    private void Start()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<AudioListener>().enabled = false;
    }
}
