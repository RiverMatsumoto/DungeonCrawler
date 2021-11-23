using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void disable()
    {
        gameObject.SetActive(false);
    }

    private void enable()
    {
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        EncounterSystem.enterBattle += disable;
        EncounterSystem.leftBattle += enable;
    }

    private void OnDisable()
    {
        EncounterSystem.enterBattle -= disable;
        EncounterSystem.leftBattle -= enable;
    }
}
