public abstract class Armor : Item, IEquipable
{
    public int defense { get; protected set; }
    public int equipmentSlot { get; set; }
    public EquipmentType equipmentType { get; set; }

    public Armor(int defense)
    {
        this.defense = defense;
    }
}
