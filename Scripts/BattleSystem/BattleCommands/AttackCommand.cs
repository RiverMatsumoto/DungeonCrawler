using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : BattleCommand
{
    public AttackCommand()
    {
        /*
        TODO add functionality to the turn commands and find a way to effectively let them communicate with everything
        TODO Make the turncommands attach to the battle entity and let the battle entity deal with multipliers and attack command
        TODO add a base attack or current attack value to turn command or battle entity
        */
    }

    public override void executeCommand()
    {
        Debug.Log(battleEntity.characterData.characterName + " attacked " + target.characterData.characterName);
    }
}
