using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    public GameObject commandButtons;
    public void selectingEnemy()
    {
        commandButtons.SetActive(false);
    }

    private void OnEnable()
    {
        EntitySelectSystem.selectingEnemy += selectingEnemy;
    }

    private void OnDisable()
    {
        EntitySelectSystem.selectingEnemy -= selectingEnemy;
    }
}
