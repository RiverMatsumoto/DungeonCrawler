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
        e.characterData.armorDefense = defense;
    }
    
    public void unequip(BattleEntity e)
    {
        e.characterData.armorDefense = 0;
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