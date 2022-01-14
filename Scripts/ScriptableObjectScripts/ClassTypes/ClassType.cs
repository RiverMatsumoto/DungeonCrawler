using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[CreateAssetMenu(fileName = "ClassType", menuName = "ScriptableObject/ClassType")]
public class ClassType : SerializedScriptableObject
{
    // TODO Add skill tree or learnable skill
    public ClassTypeEnum type;
    private string className;
    [SerializeField, ProgressBar(0, 999), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    private int[] baseMaxHealth;  //, baseMaxTalentPoints, baseStrength, baseVitality, baseWisdom, baseAgility, baseTech, baseLuck;
    [SerializeField, ProgressBar(0, 999), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    private int[] baseMaxTalentPoints;
    [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    private int[] baseStrength;
    [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    private int[] baseVitality;
    [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]

    private int[] baseWisdom;
    [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    private int[] baseAgility;
    [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    private int[] baseTech;
    [SerializeField, ProgressBar(0, 100), ListDrawerSettings(NumberOfItemsPerPage = 10, ShowIndexLabels = true)]
    private int[] baseLuck;




    public int GetBaseStats(StatsType type, int level)
    {
        int index = level - 1;
        switch (type)
        {
            case StatsType.MAX_HEALTH:
                return baseMaxHealth[index];
            case StatsType.MAX_TALENT_POINTS:
                return baseMaxHealth[index];
            case StatsType.STRENGTH:
                return baseStrength[index];
            case StatsType.VITALITY:
                return baseVitality[index];
            case StatsType.WISDOM:
                return baseVitality[index];
            case StatsType.AGILITY:
                return baseAgility[index];
            case StatsType.TECH:
                return baseTech[index];
            case StatsType.LUCK:
                return baseLuck[index];
            default:
                Debug.LogError("Somehow the stats type is invalid");
                return 1;
        }
    }

    public string getClassName() => className;

    [Button("Set Default Base Stats")]
    private void DefaultBaseStats()
    {
        baseMaxHealth = new int[100];
        baseMaxTalentPoints = new int[100];
        baseStrength = new int[100];
        baseVitality = new int[100];
        baseWisdom = new int[100];
        baseAgility = new int[100];
        baseTech = new int[100];
        baseLuck = new int[100];

    }
}

public enum ClassTypeEnum
{
    ENEMY,
    SAMURAI
}