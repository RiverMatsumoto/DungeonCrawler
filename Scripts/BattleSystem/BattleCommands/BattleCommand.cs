using System.Collections.Generic;

public abstract class BattleCommand
{
    // Formula: [STR + weaponATK] * Pwr% * PhyAtkBoost% 
    public BattleEntity commandUser { get; set; }
    public BattleEntity target { get; set; }


    public BattleCommand(BattleEntity commandUser, BattleEntity target)
    {
        this.commandUser = commandUser;
        this.target = target;
    }

    public abstract void execute();
}