using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

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
    public bool isEnemy { get; set; }
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
                battleEntity.generalUI.sortingOrder = 0;
                if (isEnemy) battleEntity.transform.localScale = new Vector3(3, 3, 3);
            }
            else
            {
                battleEntity.isBackRow = false;
                battleEntity.generalUI.sortingOrder = 10;
            }
        }
        if (!wasInserted)
        {
            Debug.LogError($"BattleEntity {battleEntity.name} could not be inserted in party");
        }
    }

    public bool isFrontRow(int partyIndex) => partyIndex <= 2;

    public void EnableSelecting()
    {
        foreach (BattleEntity e in party)
        {
            if (e == null) continue;
            e.button.enabled = true;
        }
    }

    public void DisableSelecting()
    {
        foreach (BattleEntity e in party)
        {
            if (e == null) continue;
            e.button.enabled = false;
        }
    }

    public void showParty()
    {
        foreach (BattleEntity e in party)
        {
            if (e == null) continue;
            e.gameObject.SetActive(true);
        }
    }

    public void hideParty()
    {
        foreach (BattleEntity e in party)
        {
            if (e == null) continue;
            e.gameObject.SetActive(false);
        }
    }

    public void clearParty()
    {
        for (int i = 0; i < party.Length; i++)
        {
            if (party[i] != null)
            {
                party[i].onDeath();
            }
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

    private bool isEmptyPosition(int position) => party[position] == null;
}