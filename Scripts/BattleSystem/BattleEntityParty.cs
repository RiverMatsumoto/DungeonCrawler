using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEntityParty
{
    BattleEntity[] party;
    int numEntities;
    

    public BattleEntityParty(int numEntites)
    {
        this.numEntities = numEntites;
        party = new BattleEntity[numEntites];
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
}
