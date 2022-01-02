using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BattleEntityParty : MonoBehaviour
{
    public List<BattleEntity> party;
    [Range(0,6)]
    public int numEntities;
    public bool isEnemy;
    

    public void addBattleEntity(int partyPosition, BattleEntity battleEntity)
    {
        if (party[partyPosition] == null)
        {
            party.Insert(partyPosition, battleEntity);
        }
        else
        {
            Debug.Log("There is already an entity at position " + partyPosition);
        }
    }

    public bool isFrontRow(int partyIndex)
    {
        if (partyIndex <= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void clearParty()
    {
        party.Clear();
        numEntities = 0;
    }
}
