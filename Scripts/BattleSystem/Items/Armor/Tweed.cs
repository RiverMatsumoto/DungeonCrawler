public class Tweed : Armor
{
    private const int DEFENSE = 6;
    public override string name { get; protected set; }

    public Tweed() : base(DEFENSE)
    {
        name = "Tweed";
    }
}
