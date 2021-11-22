using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData", order = 5)]
public class CharacterData : SerializedScriptableObject
{
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
}
