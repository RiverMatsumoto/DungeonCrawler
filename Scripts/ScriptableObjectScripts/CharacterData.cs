using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData", order = 5)]
public class CharacterData : SerializedScriptableObject
{
    public string characterName;
    #region Stats
    [Range(0,999)]
    public int maxHealth;
    [Range(0,999)]
    public int health;
    [Range(0,999)]
    public int maxMagicPoints;
    [Range(0,999)]
    public int magicPoints;
    [Range(1,100)]
    public int strength;
    [Range(0,999)]
    public int defense;
    [Range(1,100)]
    public int vitality;
    [Range(1,100)]
    public int agility;
    [Range(1,100)]
    public int tech;
    [Range(1,100)]
    public int luck;
    #endregion

    #region Starting stats
    [Range(0,999)]
    public readonly int startingMaxHealth;
    [Range(0,999)]
    public readonly int startingHealth;
    [Range(0,999)]
    public readonly int startingMaxMagicPoints;
    [Range(0,999)]
    public readonly int startingMagicPoints;
    [Range(1,100)]
    public readonly int startingStrength;
    [Range(0,999)]
    public readonly int startingDefense;
    [Range(1,100)]
    public readonly int startingVitality;
    [Range(1,100)]
    public readonly int startingAgility;
    [Range(1,100)]
    public readonly int startingTech;
    [Range(1,100)]
    public readonly int startingLuck;
    #endregion
    public StatusEffects.Effects currentEffects;
    public StatusEffects.Binds currentBinds;
    //todo CREATE ARMOR AND WEAPON CLASSES WITH IEQUIPPABLE AND ADD ARMOR AND WEAPONS FIELD TO THIS CLASS

    // Used to read the data in the scriptable objects as a copy or reference to use later
    public CharacterData getClone()
    {
        return Instantiate(this);
    }

    public void resetStats()
    {
        maxHealth = startingMaxHealth;
        health = startingHealth;
        maxMagicPoints = startingMaxMagicPoints;
        magicPoints = startingMagicPoints;
        strength = startingStrength;
        defense = startingDefense;
        vitality = startingVitality;
        agility = startingAgility;
        tech = startingTech;
        luck = startingLuck;
    }
    

    public Texture2D sprite;
}
