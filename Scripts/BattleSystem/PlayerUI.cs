using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using Michsky.UI.ModernUIPack;

public class PlayerUI : SerializedMonoBehaviour
{
    public BattleEntity entity;
    public TMP_Text characterName;
    public ProgressBar healthBar;
    public ProgressBar magicBar;


    public void UpdateUI()
    {
        characterName.text = entity.characterData.characterName;
        healthBar.maxValue = entity.characterData.maxHealth;
        magicBar.maxValue = entity.characterData.maxMagicPoints;
        //not actually percent, but just a value. The default min max is 0-100
        healthBar.currentPercent = entity.characterData.health;
        magicBar.currentPercent = entity.characterData.magicPoints;
    }
}