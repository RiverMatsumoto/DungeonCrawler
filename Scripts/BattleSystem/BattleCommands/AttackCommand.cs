using UnityEngine;

public class AttackCommand : BattleCommand
{
    public AttackCommand(BattleEntity commandUser, BattleEntity target) : base(commandUser, target)
    {
    }

    public override void execute()
    {
        // TODO integrate animations and battle phase speed for commands executed
        Attack attack = new Attack();
        // [STR + weaponATK] * Pwr% * PhyAtkBoost%
        // prefix "a" denotes attacker, prefix "d" denotes defender
        BattleCalculator calc = new BattleCalculator(this);
        CharacterData attacker = commandUser.characterData;
        CharacterData defender = target.characterData;
        attack.damage = attacker.attack;
        // TODO temporary for reacting to any attack.
        target.reactToAttack(this, attack);
        
        Debug.Log(commandUser.characterData.characterName 
            + " attacked " 
            + target.characterData.characterName
            + " for " + attack.damage);
    }
}
