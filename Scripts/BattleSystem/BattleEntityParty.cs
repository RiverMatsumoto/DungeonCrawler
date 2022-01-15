using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class BattleEntityParty
{
    public EntityPartyType partyGroup;
    [SerializeField]
    private BattleEntity[] party;
    public int partyCapacity { get => party.Length; }
    public int numEntities
    {
        get
        {
            int counter = 0;
            for (var i = 0; i < party.Length; i++)
            {
                if (party[i] != null) counter++;
            }
            return counter;
        }
    }
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


    public BattleEntityParty(BattleEntity[] battleEntities, bool isEnemy, EntityPartyType partyGroup = EntityPartyType.Player)
    {
        party = battleEntities;
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
    }

    public BattleEntity getBattleEntity(int index)
    {
        if (party[index] == null)
        {
            Debug.Log("Tried to access a null party member at party position: " + index);
            return null;
        }
        else
        {
            return party[index];
        }
    }

}
