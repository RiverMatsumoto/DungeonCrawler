using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<BattleEntityParty> battleEntityParties;

    public void chooseEnemyParty()
    {
        BattleSystem.instance.setEnemyParty(battleEntityParties[0]);
    }

    private void OnEnable()
    {
        BattleSystem.broadcastEnterBattle += chooseEnemyParty;
    }

    private void OnDisable()
    {
        BattleSystem.broadcastEnterBattle -= chooseEnemyParty;
    }
}
