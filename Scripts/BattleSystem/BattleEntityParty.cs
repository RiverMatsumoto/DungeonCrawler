using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class BattleEntityParty
{
    public EntityPartyType partyType;
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
    public const int MAX_PARTY_MEMBERS = 6;
    public const int MAX_BACK_ROW = 3;

    public int numBackRow
    {
        get
        {
            return numEntities - numFrontRow;
        }
    }


    public BattleEntityParty(bool isEnemy, EntityPartyType partyType = EntityPartyType.Player)
    {
        party = new BattleEntity[MAX_PARTY_MEMBERS];
        this.isEnemy = isEnemy;
        this.partyType = partyType;
    }


    public void addBattleEntity(BattleEntity battleEntity, int partyPosition)
    {
        bool wasInserted = false;
        if (isEmptyPosition(partyPosition))
        {
            // succcessfully added the battle entity to party
            wasInserted = true;
            party[partyPosition] = battleEntity;
            if (partyPosition > 2)
            {
                battleEntity.isBackRow = true;
            }
        }
        if (!wasInserted)
        {
            Debug.LogError($"BattleEntity {battleEntity.name} could not be inserted in party");
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

    private bool isEmptyPosition(int position)
    {
        if (party[position] == null)
        {
            return true;
        }
        return false;
    }
}
