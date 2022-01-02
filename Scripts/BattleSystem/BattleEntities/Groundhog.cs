using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundhog : BattleEntity
{
    public override void attack()
    {
        base.attack();
    }


    public Groundhog(CharacterData characterData)
    {
        this.characterData = characterData;
    }
}
