using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData", order = 5)]
public class CharacterData : SerializedScriptableObject
{
    public string characterName;
    public Sprite sprite;

    public ClassType classType;
    public ClassType subclassType;
    public StatusEffects.Effects currentEffects;
    public StatusEffects.Binds currentBinds;
    public bool isEnemy;
    [Range(1,100)]
    public int level;
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
    //todo CREATE ARMOR AND WEAPON CLASSES WITH IEQUIPPABLE AND ADD ARMOR AND WEAPONS FIELD TO THIS CLASS
}
