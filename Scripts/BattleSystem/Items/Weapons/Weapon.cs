public abstract class Weapon : Item, IEquipable
{
    public int attack { get; protected set; }
    public int equipmentSlot { get; set; }
    public EquipmentType equipmentType { get; set; }
    public abstract AttackType type { get; protected set; }
    public Weapon(int attack)
    {
        this.attack = attack;
    }
}
