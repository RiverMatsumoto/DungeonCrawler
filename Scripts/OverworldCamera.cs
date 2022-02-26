using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCamera : MonoBehaviour
{
    // TODO Add game event listeners
    public void OnBattleStarted()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<AudioListener>().enabled = false;
    }

    public void OnBattleEnded()
    {
        GetComponent<Camera>().enabled = true;
        GetComponent<AudioListener>().enabled = true;
    }

    private void Start()
    {
        OnBattleEnded();
    }

    private void OnEnable()
    {
        BattleEventHandler.battleStarted += OnBattleStarted;
        BattleEventHandler.battleEnded += OnBattleEnded;
    }

    private void OnDisable()
    {
        BattleEventHandler.battleStarted -= OnBattleStarted;
        BattleEventHandler.battleEnded -= OnBattleEnded;
    }
}
