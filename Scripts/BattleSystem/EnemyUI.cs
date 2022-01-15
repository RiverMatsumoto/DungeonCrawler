using UnityEngine;
using Michsky.UI.ModernUIPack;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    public BattleEntity entity;
    public ProgressBar healthBar;
    public TMP_Text enemyName;

    public void UpdateUI()
    {
        enemyName.text = entity.characterData.characterName;
        healthBar.maxValue = entity.characterData.maxHealth;
        //not actually percent, but just a value. The default min max is 0-100
        healthBar.currentPercent = entity.characterData.health;
    }
}
