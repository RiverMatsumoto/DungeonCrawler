using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedgehog : BattleEntity
{
    public override void attack()
    {
        base.attack();
    }

    public void displayStats()
    {
        Debug.Log(characterData.health);
    }

    public Hedgehog(CharacterData characterData)
    {
        this.characterData = characterData;
    }
}
