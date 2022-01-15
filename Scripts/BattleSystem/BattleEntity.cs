using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(SpriteRenderer))]
public class BattleEntity : SerializedMonoBehaviour
{
    // TODO add loot table, items, and item system
    public BattleEntityParty party;
    public CharacterData characterData;
    public BattleCommand intendedBattleCommand;
    public BattleEntity target;
    public PlayerUI playerUI;
    public EnemyUI enemyUI;
    public Sprite sprite;
    public List<BattleCommand> learnedSkills;
    public float percentDamageBoost { get => (float)damageMultiplier/100; }
    public int damageMultiplier;
    public int speedMultiplier;
    public bool isBackRow;

    public void reactToBattleCommand(BattleCommand command)
    {

    }


    public void selectEntity()
    {
        EntitySelectSystem.instance.setTarget(this);
    }

    public void setCharacterData(CharacterDataEditor data)
    {
        this.characterData = new CharacterData(data);
        sprite = data.sprite;
        GetComponent<SpriteRenderer>().sprite = sprite;
        if (data.isEnemy)
        {
            Destroy(playerUI.gameObject);
            enemyUI.UpdateUI();
        }
        else
        {
            Destroy(enemyUI.gameObject);
            playerUI.UpdateUI();
        }
    }
}
