public class Knife : Weapon
{
    public const int ATTACK = 5;
    public override string name { get; protected set; }
    public override AttackType type { get; protected set; }

    public Knife() : base(ATTACK)
    {
        name = "Knife";
    }
}
