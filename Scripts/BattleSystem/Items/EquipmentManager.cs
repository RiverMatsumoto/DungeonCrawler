
public class Equipment
{
    private Weapon slot1;
    private Weapon specialSlot1;
    private Armor slot2;
    private Armor slot3;
    private Armor slot4;
    public int WeaponAttack
    {
        get
        {
            int attack = 0;
            if (slot1 != null)
                attack += slot1.attack;
            if (specialSlot1 != null)
                attack += specialSlot1.attack;
            return attack;
        }
    }
    public int ArmorDefense
    {
        get
        {
            int defense = 0;
            if (slot2 != null)
                defense += slot2.defense;
            if (slot3 != null)
                defense += slot3.defense;
            if (slot4 != null)
                defense += slot4.defense;
            return defense;
        }
    }

    public Equipment()
    {
        
    }

    public Weapon EquipW(Weapon weapon)
    {
        Weapon val = slot1;
        slot1 = weapon;
        return val;
    }

    public Weapon SpecialEquip(Weapon weapon)
    {
        Weapon val = specialSlot1;
        specialSlot1 = weapon;
        return val;
    }

    public Weapon UnequipW()
    {
        return EquipW(null);
    }

    public Weapon UnequipSpecialW()
    {
        return SpecialEquip(null);
    }

    public Armor EquipA(Armor armor, int slot)
    {
        Armor val = null;
        if (slot == 2)
        {
            val = slot2;
            slot2 = armor;
        }
        else if (slot == 3)
        {
            val = slot3;
            slot3 = armor;
        }
        else if (slot == 4)
        {
            val = slot4;
            slot4 = armor;
        }
        return val;
    }

    public Armor UnequipA(int slot)
    {
        return EquipA(null, slot);
    }
}