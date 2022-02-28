public abstract class Armor : Item, IEquipable
{
    public int defense { get; protected set; }  

    public Armor(int defense)
    {
        this.defense = defense;
    }

    public void equip(BattleEntity e)
    {
        // add armor's stats to battle entity
        e.characterData.AddBonusStatsTo(StatsType.VITALITY, defense);
    }
    
    public void unequip(BattleEntity e)
    {
        e.characterData.SubtractBonusStatsFrom(StatsType.VITALITY, defense);
    }
}

public enum ArmorType
{
    CHESTPLATE,
    ACCESSORY,
    SHIELD,
    HEADGEAR,
    FOOTGEAR
}