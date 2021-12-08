using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData", order = 5)]
public class CharacterData : SerializedScriptableObject
{
    public string characterName;
    #region Health and magic points
    [Range(0,999)]
    public int health;
    [Range(0,999)]
    public int magicPoints;
    #endregion

    #region Stats 

    [Range(1,100)]
    public int strength;
    [Range(1,100)]
    public int vitality;
    [Range(1,100)]
    public int agility;
    [Range(1,100)]
    public int tech;
    [Range(1,100)]
    public int luck;
    [Range(1,100)]
    public int defense;
    #endregion
    public StatusEffects currentEffect;
    //todo CREATE ARMOR AND WEAPON CLASSES WITH IEQUIPPABLE AND ADD ARMOR AND WEAPONS FIELD TO THIS CLASS

    public Texture2D sprite;
}
