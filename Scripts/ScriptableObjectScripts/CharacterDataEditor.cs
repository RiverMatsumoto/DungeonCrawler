using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData", order = 5)]
public class CharacterDataEditor : SerializedScriptableObject
{
    //todo CREATE ARMOR AND WEAPON CLASSES WITH IEQUIPPABLE AND ADD ARMOR AND WEAPONS FIELD TO THIS CLASS
    public string characterName;
    public string description;
    public Sprite sprite;
    [AssetList, AssetSelector]
    public ClassType classType, subclassType;
    public StatusEffect currentStatusEffect;
    public AttackType defaultAttacktype;
    [OnValueChanged("IsEnemyUpdateData"), OnInspectorInit("IsEnemyUpdateData")]
    public bool isEnemy;
    [HorizontalGroup("Resistances/Lists", Width = 0.5F), BoxGroup("Resistances"), PropertyOrder(4), DictionaryDrawerSettings(KeyLabel = "Effect", ValueLabel = "%", KeyColumnWidth = 50), PropertySpace]
    public Dictionary<StatusEffect, int> statusEffectResistance;
    [HorizontalGroup("Resistances/Lists", Width = 0.5F), BoxGroup("Resistances"), PropertyOrder(4), DictionaryDrawerSettings(KeyLabel = "Type", ValueLabel = "%", KeyColumnWidth = 2), PropertySpace]
    public Dictionary<AttackType, int> attackTypeResistance;
    [ProgressBar(0,100, ColorGetter = "@Color.white"), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    public int level;
    #region Stats
    [ProgressBar(0,"$MAX_HP", 1F,0.2F,0.1F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    public int maxHealth;
    // [ProgressBar(0,"$MAX_HP", 1F,0.2F,0.1F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats"), DisableInEditorMode]
    // public int health;
    [ProgressBar(0,999, 0.2F,0.3F,0.9F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    public int maxTalentPoints;
    // [ProgressBar(0,999, 0.2F,0.3F,0.9F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    // public int talentPoints;
    // [ProgressBar(0,999)]
    // public int defense, magicDefense;
    [ProgressBar(0,100, 0.85F,0.15F,0.1F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    public int strength; //, vitality, wisdom, agility, tech, luck;
    [ProgressBar(0,100, 1F,0.5F,0F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    public int vitality;
    [ProgressBar(0,100, 0.5F,0.1F,1), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    public int wisdom;
    [ProgressBar(0,100, 0.9F,0.2F,0.9F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    public int agility;
    [ProgressBar(0,100, 0.1F,0.4F,1F), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    public int tech;
    [ProgressBar(0,100, 0,0.9F,0), VerticalGroup("Stats/Split/Right"), LabelText(""), PropertyOrder(2), OnValueChanged("CopyFromStats")]
    public int luck;
    #endregion
    #region Odin inspector variables
    [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Level"), PropertyOrder(1)]
    public int levelField;
    [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Max HP"), PropertyOrder(1)]
    public int maxHealthField;
    [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Max TP"), PropertyOrder(1)]
    public int maxTalentPointsField;
    [SerializeField, OnValueChanged("CopyToStats"), HorizontalGroup("Stats/Split", Width = 40, Order = 0, LabelWidth = 60), VerticalGroup("Stats/Split/Left"), PropertyOrder(1), LabelText("Strength"), TitleGroup("Stats")]
    public int strengthField;
    [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Vitality"), PropertyOrder(1)]
    public int vitalityField;
    [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Wisdom"), PropertyOrder(1)]
    public int wisdomField;
    [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Agility"), PropertyOrder(1)]
    public int agilityField;
    [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Tech"), PropertyOrder(1)]
    public int techField;
    [SerializeField, OnValueChanged("CopyToStats"), VerticalGroup("Stats/Split/Left"), LabelText("Luck"), PropertyOrder(1), PropertySpace(SpaceBefore = 0, SpaceAfter = 10)]
    public int luckField;
    private int MAX_HP;
    private void IsEnemyUpdateData() => MAX_HP = isEnemy ? 10000 : 999;
    
    private void CopyToStats()
    {
        level = levelField;
        maxHealth = maxHealthField;
        maxTalentPoints = maxTalentPointsField; 
        strength = strengthField;
        vitality = vitalityField;
        wisdom = wisdomField;
        agility = agilityField;
        tech = techField;
        luck = luckField;
    }

    private void CopyFromStats()
    {
        levelField = level;
        maxHealthField = maxHealth;
        maxTalentPointsField = maxTalentPoints;
        strengthField = strength;
        vitalityField = vitality;
        wisdomField = wisdom;
        agilityField = agility;
        techField = tech;
        luckField = luck;
    }
    #endregion

    #region CharacterData constants
    public const int DEFAULT_RESISTANCE = 100;
    #endregion

    [Button("Set Default Resistances", ButtonSizes.Small), HorizontalGroup("Resistances/Button", Width = 160), BoxGroup("Resistances"), PropertyOrder(3)]
    private void SetDefaultResistances()
    {
        attackTypeResistance = new Dictionary<AttackType, int>();
        statusEffectResistance = new Dictionary<StatusEffect, int>();
        foreach (AttackType type in Enum.GetValues(typeof(AttackType)))
        {
            attackTypeResistance.Add(type, DEFAULT_RESISTANCE);
        }
        foreach (StatusEffect type in Enum.GetValues(typeof(StatusEffect)))
        {
            statusEffectResistance.Add(type, DEFAULT_RESISTANCE);
        }
    }
}
