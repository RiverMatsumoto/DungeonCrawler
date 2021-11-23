using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudHandler : MonoBehaviour
{
    public Canvas overworldHud;
    public Canvas battleHud;
    private void Start()
    {
        // overworldHud.gameObject.SetActive(true);
        // battleHud.gameObject.SetActive(false);
        overworldHud.enabled = true;
        battleHud.enabled = false;
    }

    public void enteredBattle()
    {
        overworldHud.enabled = false;
        battleHud.enabled = true;
        // overworldHud.gameObject.SetActive(false);
        // battleHud.gameObject.SetActive(true);
    }

    public void leftBattle()
    {
        overworldHud.enabled = true;
        battleHud.enabled = false;
        // overworldHud.gameObject.SetActive(true);
        // battleHud.gameObject.SetActive(false);
    }

    #region OnEnable and OnDisable
    private void OnEnable()
    {
        EncounterSystem.enterBattle += enteredBattle;
        EncounterSystem.leftBattle += leftBattle;
    }

    private void OnDisable()
    {
        EncounterSystem.enterBattle -= enteredBattle;
        EncounterSystem.leftBattle -= leftBattle;
    }
    #endregion
}
