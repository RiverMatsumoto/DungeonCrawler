using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCamera : MonoBehaviour
{
    private void disableOverworldCamera()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<AudioListener>().enabled = false;
    }

    private void enableOverworldCamera()
    {
        GetComponent<Camera>().enabled = true;
        GetComponent<AudioListener>().enabled = true;
    }

    private void OnEnable()
    {
        BattleSystem.broadcastEnterBattle += disableOverworldCamera;
        BattleSystem.broadcastLeaveBattle += enableOverworldCamera;
    }

    private void OnDisable()
    {
        BattleSystem.broadcastEnterBattle -= disableOverworldCamera;
        BattleSystem.broadcastLeaveBattle -= enableOverworldCamera;
    }
}
