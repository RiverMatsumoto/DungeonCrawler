using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public struct CharacterDataStruct
{
    public string characterName { get; set; }
    public Sprite sprite { get; set; }
    public StatusEffect currentStatusEffect;
    public Dictionary<AttackType, int> resistances { get; set; }
    // TODO MAKE THE GET PROPERTY READ BONUS AND BASE STATS INSTEAD OF ITSELF
    #region Stats
    [OdinSerialize, PropertyRange(0,10000000)]
    public int maxHealth 
    {
        get
        {
            return baseMaxHealth + bonusMaxHealth;
        }
    }
    [OdinSerialize, PropertyRange(0,10000000)]
    public int health { get; set; }
    [OdinSerialize, PropertyRange(0,999)]
    public int maxTalentPoints 
    {
        get
        {
            return baseMaxTalentPoints + bonusMaxTalentPoints;
        }
    }
    [OdinSerialize, PropertyRange(0,999)]
    public int magicPoints { get; set; }
    [OdinSerialize, PropertyRange(0,999)]
    public int defense 
    { 
        get 
        { 
            return vitality + bonusVitality; 
        } 
    }
    [OdinSerialize, PropertyRange(0,999)]
    public int magicDefense 
    { 
        get 
        { 
            return wisdom + bonusWisdom; 
        } 
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int strength
    {
        get
        {
            return baseStrength + bonusStrength;
        }
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int vitality
    {
        get
        {
            return baseVitality + bonusVitality;
        }
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int wisdom 
    {
        get
        {
            return baseWisdom + bonusWisdom;
        }
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int agility 
    { 
        get
        {
            return baseAgility + bonusAgility;
        }
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int tech 
    {
        get
        {
            return baseTech + bonusTech;
        }
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int luck 
    {
        get
        {
            return baseLuck + bonusLuck;
        }
    }
    #endregion
    #region base stats and additional stats
    
    [OdinSerialize, PropertyRange(0,10000000)]
    private int baseMaxHealth { get; set; }
    [OdinSerialize, PropertyRange(0,999)]
    private int baseMaxTalentPoints { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int baseStrength { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int baseVitality { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int baseWisdom { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int baseAgility { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int baseTech { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int baseLuck { get; set; }

    [OdinSerialize, PropertyRange(0,10000000)]
    private int bonusMaxHealth { get; set; }
    [OdinSerialize, PropertyRange(0,999)]
    private int bonusMaxTalentPoints { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int bonusStrength { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int bonusVitality { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int bonusWisdom { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int bonusAgility { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int bonusTech { get; set; }
    [OdinSerialize, PropertyRange(0,100)]
    private int bonusLuck { get; set; }
    #endregion
    public bool isEnemy;
    const int maxPlayerHealth = 999;

    public void AddBonusStatsTo(StatsType type, int bonusAmount)
    {
        switch (type)
        {
            case StatsType.MAX_HEALTH:
                bonusMaxHealth += bonusAmount;
                break;
            case StatsType.MAX_TALENT_POINTS:
                bonusMaxTalentPoints += bonusAmount;
                break;
            case StatsType.STRENGTH:
                bonusStrength += bonusAmount;
                break;
            case StatsType.VITALITY:
                bonusVitality += bonusAmount;
                break;
            case StatsType.WISDOM:
                bonusWisdom += bonusAmount;
                break;
            case StatsType.AGILITY:
                bonusAgility += bonusAmount;
                break;
            case StatsType.TECH:
                bonusMaxTalentPoints += bonusAmount;
                break;
            case StatsType.LUCK:
                bonusLuck += bonusAmount;
                break;
        }
    }

    public void SubtractBonusStatsFrom(StatsType type, int bonusAmount)
    {
        switch (type)
        {
            case StatsType.MAX_HEALTH:
                bonusMaxHealth -= bonusAmount;
                break;
            case StatsType.MAX_TALENT_POINTS:
                bonusMaxTalentPoints -= bonusAmount;
                break;
            case StatsType.STRENGTH:
                bonusStrength -= bonusAmount;
                break;
            case StatsType.VITALITY:
                bonusVitality -= bonusAmount;
                break;
            case StatsType.WISDOM:
                bonusWisdom -= bonusAmount;
                break;
            case StatsType.AGILITY:
                bonusAgility -= bonusAmount;
                break;
            case StatsType.TECH:
                bonusMaxTalentPoints -= bonusAmount;
                break;
            case StatsType.LUCK:
                bonusLuck -= bonusAmount;
                break;
        }
    }

    public CharacterDataStruct(CharacterData data)
    {
        characterName = data.characterName;
        sprite = data.sprite;
        resistances = data.attackTypeResistance;

        baseMaxHealth = data.maxHealth;
        health = data.maxHealth;
        baseMaxTalentPoints = data.maxTalentPoints;
        magicPoints = data.maxTalentPoints;
        baseStrength = data.strength;
        baseVitality = data.vitality;
        baseWisdom = data.wisdom;
        baseAgility = data.agility;
        baseTech = data.tech;
        baseLuck = data.luck;
        currentStatusEffect = data.currentStatusEffect;
        isEnemy = data.isEnemy;

        if (data.classType == null)
        {
            baseMaxHealth = 0;
            baseMaxTalentPoints = 0;
            baseStrength = 0;
            baseVitality = 0;
            baseWisdom = 0;
            baseAgility = 0;
            baseTech = 0;
            baseLuck = 0;
            
        }
        else
        {
            baseMaxHealth = data.classType.GetBaseStats(StatsType.MAX_HEALTH, data.level);
            baseMaxTalentPoints = data.classType.GetBaseStats(StatsType.MAX_TALENT_POINTS, data.level);
            baseStrength = data.classType.GetBaseStats(StatsType.STRENGTH, data.level);
            baseVitality = data.classType.GetBaseStats(StatsType.VITALITY, data.level);
            baseWisdom = data.classType.GetBaseStats(StatsType.WISDOM, data.level);
            baseAgility = data.classType.GetBaseStats(StatsType.AGILITY, data.level);
            baseTech = data.classType.GetBaseStats(StatsType.TECH, data.level);
            baseLuck = data.classType.GetBaseStats(StatsType.LUCK, data.level);
        }


        bonusMaxHealth = 0;
        bonusMaxTalentPoints = 0;
        bonusStrength = 0;
        bonusVitality = 0;
        bonusWisdom = 0;
        bonusAgility= 0;
        bonusTech = 0;
        bonusLuck = 0;
    }
}
