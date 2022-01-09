using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public struct CharacterDataStruct
{
    public string name { get; set; }
    public Sprite sprite { get; set; }
    #region Stats
    [ShowInInspector, PropertyRange(0,10000000)]
    public int maxHealth { get; set; }
    [ShowInInspector, PropertyRange(0,10000000)]
    public int health { get; set; }
    [ShowInInspector, PropertyRange(0,999)]
    public int maxMagicPoints { get; set; }
    [ShowInInspector, PropertyRange(0,999)]
    public int magicPoints { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int strength { get; set; }
    [ShowInInspector, PropertyRange(0,999)]
    public int defense { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int vitality { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int agility { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int tech { get; set; }
    [ShowInInspector, PropertyRange(1,100)]
    public int luck { get; set; }
    #endregion
    #region Status effects
    public StatusEffects.Effects currentEffects { get; set; }
    public StatusEffects.Binds currentBinds { get; set; }
    #endregion
    public bool isEnemy;
    const int maxPlayerHealth = 999;

    public CharacterDataStruct(CharacterData characterData)
    {
        name = characterData.name;
        sprite = characterData.sprite;
        maxHealth = characterData.maxHealth;
        health = characterData.health;
        maxMagicPoints = characterData.maxMagicPoints;
        magicPoints = characterData.magicPoints;
        strength = characterData.strength;
        defense = characterData.defense;
        vitality = characterData.vitality;
        agility = characterData.agility;
        tech = characterData.tech;
        luck = characterData.luck;
        currentEffects = characterData.currentEffects;
        currentBinds = characterData.currentBinds;
        isEnemy = characterData.isEnemy;
    }
}
