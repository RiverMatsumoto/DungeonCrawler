using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public struct CharacterDataStruct
{
    public string characterName { get; set; }
    public Sprite sprite { get; set; }
    public StatusEffects.Effects currentEffects { get; set; }
    public StatusEffects.Binds currentBinds { get; set; }
    // public int level { get; set; }
    #region Stats
    [ShowInInspector, PropertyRange(0,10000000)]
    public int maxHealth { get; set; }
    [ShowInInspector, PropertyRange(0,10000000)]
    public int health { get; set; }
    [ShowInInspector, PropertyRange(0,999)]
    public int maxMagicPoints { get; set; }
    [ShowInInspector, PropertyRange(0,999)]
    public int magicPoints { get; set; }
    [ShowInInspector, PropertyRange(0,999)]
    public int defense { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int strength { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int vitality { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int agility { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int tech { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int luck { get; set; }
    #endregion
    #region base stats and additional stats
    [ShowInInspector, PropertyRange(0,10000000)]
    public int baseMaxHealth { get; set; }
    [ShowInInspector, PropertyRange(0,999)]
    public int baseMaxMagicPoints { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int baseStrength { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int baseVitality { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int baseAgility { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int baseTech { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int baseLuck { get; set; }

    [ShowInInspector, PropertyRange(0,10000000)]
    public int bonusMaxHealth { get; set; }
    [ShowInInspector, PropertyRange(0,999)]
    public int bonusMaxMagicPoints { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int bonusStrength { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int bonusVitality { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int bonusAgility { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int bonusTech { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int bonusLuck { get; set; }

    #endregion
    #region Status effects
    #endregion
    public bool isEnemy;
    const int maxPlayerHealth = 999;

    public CharacterDataStruct(CharacterData data)
    {
        characterName = data.characterName;
        sprite = data.sprite;
        maxHealth = data.maxHealth;
        health = data.health;
        maxMagicPoints = data.maxMagicPoints;
        magicPoints = data.magicPoints;
        strength = data.strength;
        defense = data.defense;
        vitality = data.vitality;
        agility = data.agility;
        tech = data.tech;
        luck = data.luck;
        currentEffects = data.currentEffects;
        currentBinds = data.currentBinds;
        isEnemy = data.isEnemy;

        if (data.classType == null)
        {
            baseMaxHealth = 0;
            baseMaxMagicPoints = 0;
            baseStrength = 0;
            baseVitality = 0;
            baseAgility = 0;
            baseTech = 0;
            baseLuck = 0;
            
        }
        else
        {
            baseMaxHealth = data.classType.GetBaseStats(StatsType.MAX_HEALTH, data.level);
            baseMaxMagicPoints = data.classType.GetBaseStats(StatsType.MAX_MAGIC_POINTS, data.level);
            baseStrength = data.classType.GetBaseStats(StatsType.STRENGTH, data.level);
            baseVitality = data.classType.GetBaseStats(StatsType.VITALITY, data.level);
            baseAgility = data.classType.GetBaseStats(StatsType.AGILITY, data.level);
            baseTech = data.classType.GetBaseStats(StatsType.TECH, data.level);
            baseLuck = data.classType.GetBaseStats(StatsType.LUCK, data.level);
        }


        bonusMaxHealth = 0;
        bonusMaxMagicPoints = 0;
        bonusStrength = 0;
        bonusVitality = 0;
        bonusAgility = 0;
        bonusTech = 0;
        bonusLuck = 0;
    }
}
