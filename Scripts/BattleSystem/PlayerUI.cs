using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Michsky.UI.ModernUIPack;
using Sirenix.OdinInspector;

public class PlayerUI : MonoBehaviour
{
    public BattleEntity entity;
    public TMP_Text characterName;
    public ProgressBar healthBar;
    public ProgressBar magicBar;
    public Image background;

    [Button]
    public void AddHealth()
    {
        healthBar.currentPercent = 30;
    }

    [Button]
    public void UpdateUI()
    {
        characterName.text = entity.characterData.characterName;
        healthBar.maxValue = entity.characterData.maxHealth;
        magicBar.maxValue = entity.characterData.maxTalentPoints;
        //not actually percent, but just a value. The default min max is 0-100
        healthBar.currentPercent = entity.characterData.Health;
        magicBar.currentPercent = entity.characterData.TalentPoints;
    }
}