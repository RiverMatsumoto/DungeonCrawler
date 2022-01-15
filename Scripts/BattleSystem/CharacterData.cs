using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class CharacterData
{
    public string characterName { get; set; }
    public string description { get; set; }
    public Sprite sprite { get; set; }
    public StatusEffect currentStatusEffect;
    public Dictionary<AttackType, int> resistances { get; set; }
    public AttackType defaultAttackType;
    // TODO MAKE THE GET PROPERTY READ BONUS AND BASE STATS INSTEAD OF ITSELF
    #region Stats
    [OdinSerialize, PropertyRange(0,10000000)]
    public int maxHealth 
    {
        get => baseMaxHealth + bonusMaxHealth;
    }
    [OdinSerialize, PropertyRange(0,10000000)]
    public int health { get; set; }
    [OdinSerialize, PropertyRange(0,999)]
    public int maxTalentPoints 
    {
        get => baseMaxTalentPoints + bonusMaxTalentPoints;
    }
    [OdinSerialize, PropertyRange(0,999)]
    public int magicPoints { get; set; }
    [OdinSerialize, PropertyRange(0,999)]
    public int defense 
    { 
        get => vitality + bonusVitality;
    }
    [OdinSerialize, PropertyRange(0,999)]
    public int magicDefense 
    { 
        get => wisdom + bonusWisdom; 
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int strength
    {
        get => baseStrength + bonusStrength;
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int vitality
    {
        get => baseVitality + bonusVitality;
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int wisdom 
    {
        get => baseWisdom + bonusWisdom;
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int agility 
    { 
        get => baseAgility + bonusAgility;
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int tech 
    {
        get => baseTech + bonusTech;
    }
    [OdinSerialize, PropertyRange(0,100)]
    public int luck 
    {
        get => baseLuck + bonusLuck;
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
            case StatsType.MAX_HEALTH: bonusMaxHealth += bonusAmount; break;
            case StatsType.MAX_TALENT_POINTS: bonusMaxTalentPoints += bonusAmount; break;
            case StatsType.STRENGTH: bonusStrength += bonusAmount; break;
            case StatsType.VITALITY: bonusVitality += bonusAmount; break;
            case StatsType.WISDOM: bonusWisdom += bonusAmount; break;
            case StatsType.AGILITY: bonusAgility += bonusAmount; break;
            case StatsType.TECH: bonusMaxTalentPoints += bonusAmount; break;
            case StatsType.LUCK: bonusLuck += bonusAmount; break;
        }
    }

    public void SubtractBonusStatsFrom(StatsType type, int bonusAmount)
    {
        switch (type)
        {
            case StatsType.MAX_HEALTH: bonusMaxHealth -= bonusAmount; break;
            case StatsType.MAX_TALENT_POINTS: bonusMaxTalentPoints -= bonusAmount; break;
            case StatsType.STRENGTH: bonusStrength -= bonusAmount; break;
            case StatsType.VITALITY: bonusVitality -= bonusAmount; break;
            case StatsType.WISDOM: bonusWisdom -= bonusAmount; break;
            case StatsType.AGILITY: bonusAgility -= bonusAmount; break;
            case StatsType.TECH: bonusMaxTalentPoints -= bonusAmount; break;
            case StatsType.LUCK: bonusLuck -= bonusAmount; break;
        }
    }

    public CharacterData(CharacterDataEditor data)
    {
        characterName = data.characterName;
        description = data.description;
        sprite = data.sprite;
        resistances = data.attackTypeResistance;
        defaultAttackType = data.defaultAttacktype;
        currentStatusEffect = data.currentStatusEffect;
        isEnemy = data.isEnemy;

        if (data.classType.type == ClassTypeEnum.ENEMY)
        {
            baseMaxHealth = data.maxHealth;
            baseMaxTalentPoints = data.maxTalentPoints;
            baseStrength = data.strength;
            baseVitality = data.vitality;
            baseWisdom = data.wisdom;
            baseAgility = data.agility;
            baseTech = data.tech;
            baseLuck = data.luck;
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
        health = data.maxHealth;
        magicPoints = data.maxTalentPoints;


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
