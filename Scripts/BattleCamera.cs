using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    // TODO add game event listeners
    public void disableBattleCamera()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<AudioListener>().enabled = false;
    }

    public void enableBattleCamera()
    {
        GetComponent<Camera>().enabled = true;
        GetComponent<AudioListener>().enabled = true;
    }


    private void Start()
    {
        disableBattleCamera();
    }

    private void OnBattleStarted()
    {
        enableBattleCamera();
    }

    private void OnBattleEnded()
    {
        disableBattleCamera();
    }

    private void OnEnable()
    {
        BattleEventHandler.battleStarted += enableBattleCamera;
        BattleEventHandler.battleEnded += disableBattleCamera;
    }

    private void OnDisable()
    {
        BattleEventHandler.battleStarted -= enableBattleCamera;
        BattleEventHandler.battleEnded -= disableBattleCamera;
    }
}
