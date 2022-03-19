using UnityEngine;
using Sirenix.OdinInspector;

public abstract class ClassType : SerializedScriptableObject
{
    // TODO Add skill tree or learnable skill
    public abstract ClassTypeEnum type { get; set; }
    public abstract int GetBaseMaxHealth(int level);
    public abstract int GetBaseMaxTalentPoints(int level);
    public abstract int GetBaseStrength(int level);
    public abstract int GetBaseVitality(int level);
    public abstract int GetBaseWisdom(int level);
    public abstract int GetBaseAgility(int level);
    public abstract int GetBaseTech(int level);
    public abstract int GetBaseLuck(int level);



    public int GetBaseStats(StatsType type, int level)
    {
        switch (type)
        {
            case StatsType.MAX_HEALTH: return GetBaseMaxHealth(level);
            case StatsType.MAX_TALENT_POINTS: return GetBaseMaxTalentPoints(level);
            case StatsType.STRENGTH: return GetBaseStrength(level);
            case StatsType.VITALITY: return GetBaseVitality(level);
            case StatsType.WISDOM: return GetBaseWisdom(level);
            case StatsType.AGILITY: return GetBaseAgility(level);
            case StatsType.TECH: return GetBaseTech(level);
            case StatsType.LUCK: return GetBaseLuck(level);
            default:
                Debug.LogError("Somehow the stats type is invalid");
                return 1;
        }
    }
    //Might use later to bake in stats
    // public ClassTypeEnum type;
    // private string className;
    // [SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    // private int[] baseMaxHealth;  //, baseMaxTalentPoints, baseStrength, baseVitality, baseWisdom, baseAgility, baseTech, baseLuck;
    // [SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    // private int[] baseMaxTalentPoints;
    // [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    // private int[] baseStrength;
    // [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    // private int[] baseVitality;
    // [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]

    // private int[] baseWisdom;
    // [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    // private int[] baseAgility;
    // [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    // private int[] baseTech;
    // [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    // private int[] baseLuck;
}

public enum ClassTypeEnum
{
    EMPTY = 0,
    SAMURAI = 1,
    PROTECTOR = 2,
    ALCHEMIST = 3,
    LANDSKNECHT = 4,
    MEDIC = 5,
    TECHNICIAN = 6,
    HEXER = 7,
    SURVIVALIST = 8,
    DARK_HUNTER = 9
}