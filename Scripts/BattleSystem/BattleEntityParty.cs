using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BattleEntityParty
{
    public EntityPartyType partyGroup;
    public BattleEntity[] party;
    [Range(0, 6)]
    public int numEntities;
    public bool isEnemy;
    public int numFrontRow
    {
        get
        {
            int counter = 0;
            for (var i = 0; i < party.Length; i++)
            {
                if (party[i] == null) { continue; }
                if (!party[i].isBackRow) { counter++; }
            }
            return counter;
        }
    }

    public int numBackRow
    {
        get
        {
            return numEntities - numFrontRow;
        }
    }


    public BattleEntityParty(BattleEntity[] battleEntities, bool isEnemy, EntityPartyType partyGroup)
    {
        party = battleEntities;
        numEntities = battleEntities.Length;
        this.isEnemy = isEnemy;
        this.partyGroup = partyGroup;
    }


    public void addBattleEntity(BattleEntity battleEntity)
    {
        bool wasInserted = false;
        for (int i = 0; i < 6; i++)
        {
            if (party[i] == null)
            {
                wasInserted = true;
                numEntities++;
                party[i] = battleEntity;
            }
        }
        if (!wasInserted)
        {
            Debug.Log("BattleEntity could not be inserted in party");
        }
    }

    public bool isFrontRow(int partyIndex)
    {
        if (partyIndex <= 2)
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
        for (int i = 0; i < party.Length; i++)
        {
            party[i] = null;
        }
        numEntities = 0;
    }

    public BattleEntity getBattleEntity(int index)
    {
        if (party[index] == null)
        {
            return null;
        }
        else
        {
            Debug.Log("Accessed index " + index);
            return party[index];
        }
    }

}
