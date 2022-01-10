using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "ClassType", menuName = "ScriptableObject/SamuraiClass")]
public class ClassType : SerializedScriptableObject
{
    // TODO Add skill tree or learnable skill
    public ClassTypeEnum type;
    public int[] baseMaxHealth;
    public int[] baseMaxMagicPoints;
    public int[] baseStrength;
    public int[] baseVitality;
    public int[] baseAgility;
    public int[] baseTech;
    public int[] baseLuck;


    // add base stats 
    public int GetBaseStats(StatsType type, int level)
    {
        switch (type)
        {
            case StatsType.MAX_HEALTH:
                return baseMaxHealth[level];
            case StatsType.MAX_MAGIC_POINTS:
                return baseMaxHealth[level];
            case StatsType.STRENGTH:
                return baseStrength[level];
            case StatsType.VITALITY:
                return baseVitality[level];
            case StatsType.AGILITY:
                return baseAgility[level];
            case StatsType.TECH:
                return baseTech[level];
            case StatsType.LUCK:
                return baseLuck[level];
            default:
                Debug.LogError("Somehow the stats type is invalid");
                return 1;
        }
        
    }

    [Button("Set Default Base Stats")]
    public void DefaultBaseStats()
    {
        baseStrength = new int[100];
        baseVitality = new int[100];
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