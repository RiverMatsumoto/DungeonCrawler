using UnityEngine;

public class AttackCommand : BattleCommand
{
    private Attack attack;
    public AttackCommand(BattleEntity commandUser, BattleEntity target) : base(commandUser, target)
    {

    }

    public override void execute()
    {
        // TODO integrate animations and battle phase speed for commands executed
        attack = new Attack();
        // [STR + weaponATK] * Pwr% * PhyAtkBoost%
        // prefix "a" denotes attacker, prefix "d" denotes defender
        BattleCalculator calc = new BattleCalculator();
        CharacterData attacker = commandUser.characterData;
        CharacterData defender = target.characterData;
        attack.damage = attacker.attack;
        attack.type = attacker.defaultAttackType;
        commandAnimEndListener.Subscribe();
        // TODO temporary for reacting to any attack.

        target.receiveAttack(this, attack);
        
        Debug.Log(
            commandUser.characterData.characterName 
            + " attacked " 
            + target.characterData.characterName
            + " for " + attack.damage
        );
    }

    public override void sendCommand()
    {
        Debug.Log("Sent the command from CommandAnimationEnd");
        // target.receiveAttack(this, attack);

    }
}
