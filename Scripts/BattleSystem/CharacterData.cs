using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CharacterData
{
    public string characterName { get; set; }
    public string description { get; set; }
    public Sprite sprite { get; set; }
    public StatusEffect currentStatusEffect;
    public Dictionary<AttackType, int> resistances { get; set; }

    #region Equipment
    public AttackType defaultAttackType;
    public int MAX_WEAPON_SLOTS;
    public int MAX_ARMOR_SLOTS;
    public Equipment equipment { get; set; }
    #endregion

    // TODO MAKE THE GET PROPERTY READ BONUS AND BASE STATS INSTEAD OF ITSELF
    #region Stats
    public int attack 
    { 
        get
        {
            int atk = equipment.WeaponAttack + strength;
            float finalMultiplier = 1;
            foreach (float atkMultiplier in physAtkMultipliers) 
            {
                finalMultiplier *= atkMultiplier;
            }
            return (int) (atk * finalMultiplier); 
        } 
    }
    public int tecAttack
    {
        get
        {
            int tecAtk = (int)(tech * 1.5F);
            float finalMultiplier = 1;
            foreach (float multiplier in tecAtkMultipliers)
            {
                finalMultiplier *= multiplier;
            }
            return (int)(tecAtk * finalMultiplier);
        }
    }
    public List<float> physAtkMultipliers { get; set; }
    public List<float> tecAtkMultipliers { get; set; }
    public List<float> physDefMultipliers { get; set; }
    public List<float> tecDefMultipliers { get; set; }

    [SerializeField, PropertyRange(0,10000000)]
    public int maxHealth 
    {
        get => baseMaxHealth + bonusMaxHealth;
    }
    [SerializeField, PropertyRange(0, 10000000)]
    private int health;
    public int Health 
    {
        get { return health; }
        set
        {
            if (value > maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                health = value;
            }
        } 
    }
    [SerializeField, PropertyRange(0,999)]
    public int maxTalentPoints 
    {
        get => baseMaxTalentPoints + bonusMaxTalentPoints;
    }
    [SerializeField, PropertyRange(0, 999)]
    private int talentPoints;
    public int TalentPoints 
    {
        get { return talentPoints; }
        set
        {
            if (talentPoints + value > maxTalentPoints)
            {
                talentPoints = maxTalentPoints;
            }
            else
            {
                talentPoints += value;
            }
        }
    }
    [SerializeField, PropertyRange(0,999)]
    public int defense 
    { 
        get
        {
            int def = vitality + equipment.ArmorDefense;
            float finalMultiplier = 1;
            foreach (float multiplier in physDefMultipliers)
            {
                finalMultiplier *= multiplier;
            }
            return (int)(def * finalMultiplier);
        }
    }
    [SerializeField, PropertyRange(0,999)]
    public int tecDefense 
    { 
        get
        {
            int tecDef = wisdom + (int)(equipment.ArmorDefense * 0.8);
            float finalMultiplier = 1;
            foreach (float multiplier in tecDefMultipliers)
            {
                finalMultiplier *= multiplier;
            }
            return (int)(tecDef * finalMultiplier);
        }
    }
    [SerializeField, PropertyRange(0,100)]
    public int strength
    {
        get => baseStrength + bonusStrength;
    }
    [SerializeField, PropertyRange(0,100)]
    public int vitality
    {
        get => baseVitality + bonusVitality;
    }
    [SerializeField, PropertyRange(0,100)]
    public int wisdom 
    {
        get => baseWisdom + bonusWisdom;
    }
    [SerializeField, PropertyRange(0,100)]
    public int agility 
    { 
        get => baseAgility + bonusAgility;
    }
    [SerializeField, PropertyRange(0,100)]
    public int tech 
    {
        get => baseTech + bonusTech;
    }
    [SerializeField, PropertyRange(0,100)]
    public int luck 
    {
        get => baseLuck + bonusLuck;
    }
    #endregion
    #region base stats and additional stats
    
    [SerializeField, PropertyRange(0,10000000)]
    private int baseMaxHealth { get; set; }
    [SerializeField, PropertyRange(0,999)]
    private int baseMaxTalentPoints { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int baseStrength { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int baseVitality { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int baseWisdom { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int baseAgility { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int baseTech { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int baseLuck { get; set; }

    [SerializeField, PropertyRange(0,10000000)]
    private int bonusMaxHealth { get; set; }
    [SerializeField, PropertyRange(0,999)]
    private int bonusMaxTalentPoints { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int bonusStrength { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int bonusVitality { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int bonusWisdom { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int bonusAgility { get; set; }
    [SerializeField, PropertyRange(0,100)]
    private int bonusTech { get; set; }
    [SerializeField, PropertyRange(0,100)]
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

        if (data.classType == null)
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
        // TODO INITALIZE EQUIPMENT SLOTS
        health = data.maxHealth;
        talentPoints = data.maxTalentPoints;

        bonusMaxHealth = 0;
        bonusMaxTalentPoints = 0;
        bonusStrength = 0;
        bonusVitality = 0;
        bonusWisdom = 0;
        bonusAgility= 0;
        bonusTech = 0;
        bonusLuck = 0;

        // Equipment
        equipment = new Equipment();
        MAX_WEAPON_SLOTS = 1;
        MAX_ARMOR_SLOTS = 3;
    }
}
