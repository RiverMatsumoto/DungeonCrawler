public abstract class Weapon : Item, IEquipable
{
    public int attack { get; protected set; }
    public abstract AttackType type { get; protected set; }
    public Weapon(int attack)
    {
        this.attack = attack;
    }

    public void equip(BattleEntity e)
    {
        // TODO add resistances or attack type functionality
        // add weapons's stats to battle entity

    }
    
    public void unequip(BattleEntity e)
    {
        // 
    }
}
public enum WeaponType
{
    DAGGER,
    SWORD,
    BOW,
    STAFF,
    KATANA,
    GUN
}
