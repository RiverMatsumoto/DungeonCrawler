using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    public GameObject commandButtons;

    public void selectEnemy()
    {
        disableCommandButtons();
    }

    public void enableCommandButtons()
    {
        commandButtons.SetActive(true);
    }

    public void disableCommandButtons()
    {
        commandButtons.SetActive(false);
    }

    private void OnEnable()
    {
        EntitySelectSystem.selectingEnemy += selectEnemy;
    }

    private void OnDisable()
    {
        EntitySelectSystem.selectingEnemy -= selectEnemy;
    }
}
