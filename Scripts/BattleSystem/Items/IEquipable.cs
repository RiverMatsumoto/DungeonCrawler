public interface IEquipable
{
    EquipmentType equipmentType { get; set; }
    int equipmentSlot { get; set; }
}
public enum EquipmentType
{
    DAGGER = 0,
    SWORD = 1,
    BOW = 2,
    STAFF = 3,
    KATANA = 4,
    GUN = 5,
    HEAVY_ARMOR = 6,
    MEDIUM_ARMOR = 7,
    LIGHT_ARMOR = 8,
    HEADGEAR = 9,
    ARMGEAR = 10,
    FOOTGEAR = 11,
    SHIELD = 12,
    ACCESSORY = 13
}
