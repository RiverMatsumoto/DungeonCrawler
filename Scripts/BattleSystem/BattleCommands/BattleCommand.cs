public abstract class BattleCommand
{
    // Formula: [STR + weaponATK] * Pwr% * PhyAtkBoost% 
    public BattleEntity commandUser { get; set; }
    public BattleEntity target { get; set; }
    protected CommandAnimationListener commandAnimEndListener;

    public BattleCommand(BattleEntity commandUser, BattleEntity target)
    {
        this.commandUser = commandUser;
        this.target = target;
        commandAnimEndListener = new CommandAnimationListener(sendCommand);
        commandAnimEndListener.Unsubscribe();
    }

    public abstract void execute();
    public virtual void sendCommand()
    {
        target.receiveCommand(this);
    }
}