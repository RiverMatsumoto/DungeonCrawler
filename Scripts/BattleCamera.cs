using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    private void disableBattleCamera()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<AudioListener>().enabled = false;
    }

    private void enableBattleCamera()
    {
        GetComponent<Camera>().enabled = true;
        GetComponent<AudioListener>().enabled = true;
    }

    private void OnEnable()
    {
        BattleSystem.broadcastEnterBattle += enableBattleCamera;
        BattleSystem.broadcastLeaveBattle += disableBattleCamera;
    }

    private void OnDisable()
    {
        BattleSystem.broadcastEnterBattle -= enableBattleCamera;
        BattleSystem.broadcastLeaveBattle -= disableBattleCamera;
    }

    private void Start()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<AudioListener>().enabled = false;
    }
}
