public class BattleCalculator
{
    public int CalculatePhysDamageTaken(Attack attack, BattleCommand command)
    {
        CharacterData data = command.target.characterData;
        float defense = data.defense;
        float damage = attack.damage;
        foreach (float defMultiplier in data.physAtkMultipliers)
        {
            defense *= defMultiplier;
        }
        
        return (int) damage;
    }

    public int CalculateTecDamageTaken(Attack attack, BattleCommand command)
    {
        CharacterData data = command.target.characterData;
        float damage = (data.tecDefense) * data.tecDefense;
        foreach (float defMultiplier in data.tecDefMultipliers)
        {
            damage *= defMultiplier;
        }
        return (int) damage;
    }
}
