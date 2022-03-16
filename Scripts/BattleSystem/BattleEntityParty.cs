using UnityEngine;
using Sirenix.OdinInspector;

public class BattleEntityParty
{
    public EntityPartyType partyType;
    [ShowInInspector]
    public BattleEntity[] party { get; }
    public int partyCapacity { get => party.Length; }
    public int size
    {
        get
        {
            int counter = 0;
            for (var i = 0; i < party.Length; i++)
                if (party[i] != null)
                    counter++;
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
            return size - numFrontRow;
        }
    }
    public bool isEmpty
    {
        get
        {
            if (party == null) return true;
            bool empty = true;
            for (var i = 0; i < party.Length; i++) 
                if (party[i] == null) return false;
            return empty;
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
            return null;
        }
        else
        {
            return party[index];
        }
    }

    private bool isEmptyPosition(int position) => party[position] == null;

    public PartyIterator GetIterator() => new PartyIterator(party);

}
public class PartyIterator
{
    public BattleEntity[] entities;
    [ShowInInspector]
    private int position;
    public PartyIterator(BattleEntity[] entities)
    {
        this.entities = entities;
        position = -1;
    }
    
    public bool HasNext()
    {
        int i = position;
        while (i < entities.Length - 1)
        {
            if (entities[++i] != null)
                return true;
        }
        return false;
    }

    public bool HasPrev()
    {
        int i = position;
        while (i > -1)
        {
            if (entities[i--] != null)
                return true;
        }
        return false;
    }

    public BattleEntity Next()
    {
        if (!HasNext())
        {
            Debug.LogError("Try to get next nonexistant battle entity in the party");
            return null;
        }
        while (++position < entities.Length)
        {
            if (entities[position] != null) { return entities[position]; }
        }
        return null;
    }

    public BattleEntity Prev()
    {
        if (!HasPrev())
        {
            Debug.LogError("Try to get previous nonexistant battle entity in the party");
            return null;
        }
        while (position-- > -1)
        {
            if (entities[position] != null) { return entities[position]; }
        }
        return null;
    }
}