using System.Collections.Generic;

public abstract class BattleCommand
{
    // Formula: [STR + weaponATK] * Pwr% * PhyAtkBoost% 
    protected BattleEntity commandUser;
    protected BattleEntity target;
    protected List<float> physAtkBoost;
    protected List<float> elemAtkBoost;


    public BattleCommand(BattleEntity commandUser, BattleEntity target)
    {
        this.commandUser = commandUser;
        this.target = target;
        physAtkBoost = new List<float>();
        elemAtkBoost = new List<float>();
    }

    public abstract void execute();
}