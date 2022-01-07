using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Canvas overworldHud;
    public Canvas battleHud;
    public Button battleFirstSelectedButton;
    private void Start()
    {
        // overworldHud.gameObject.SetActive(true);
        // battleHud.gameObject.SetActive(false);
        overworldHud.enabled = true;
        battleHud.enabled = false;
    }

    public void enterBattle()
    {
        overworldHud.enabled = false;
        battleHud.enabled = true;
        battleFirstSelectedButton.Select();
        // overworldHud.gameObject.SetActive(false);
        // battleHud.gameObject.SetActive(true);
    }

    public void endBattle()
    {
        overworldHud.enabled = true;
        battleHud.enabled = false;
        // overworldHud.gameObject.SetActive(true);
        // battleHud.gameObject.SetActive(false);
    }

    #region OnEnable and OnDisable
    private void OnEnable()
    {
        BattleSystem.broadcastEnterBattle += enterBattle;
        BattleSystem.broadcastLeaveBattle += endBattle;
    }

    private void OnDisable()
    {
        BattleSystem.broadcastEnterBattle -= enterBattle;
        BattleSystem.broadcastLeaveBattle -= endBattle;
    }
    #endregion
}
