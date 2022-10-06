using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BattleEntity : SerializedMonoBehaviour
{
    #region Events
    private delegate void wasAttackedEvent(int damage);
    private event wasAttackedEvent wasAttacked;
    #endregion
    // TODO add loot table, items, and item system
    public BattleEntityParty party;
    public CharacterData characterData;
    public BattleCommand intendedBattleCommand;
    public BattleEntity target;
    public Canvas generalUI;
    public PlayerUI playerUI;
    public EnemyUI enemyUI;
    public Sprite sprite;
    public Image portrait;
    public Button button;
    public List<BattleCommand> learnedSkills;
    public float percentDamageBoost { get => (float)damageMultiplier/100; }
    public int damageMultiplier;
    public int speedMultiplier;
    public bool isBackRow;

    public void receiveAttack(BattleCommand command, Attack attack)
    {
        // TODO temporary. Might create "wasAttacked" event or let commands listen to the wasAttacked event
        wasAttacked.Invoke(attack.damage);
    }

    public void receiveCommand(BattleCommand command)
    {

    }

    public void setHighlight(bool set)
    {
        playerUI.setHighlight(set);
    }


    public void selectEntity()
    {
        PlayerSelectSystem.Instance.SelectPlayer(this);
    }

    public void onDeath()
    {
        Destroy(this.gameObject);
    }

    public void Initialize(CharacterDataEditor data)
    {
        button.enabled = false;

        this.characterData = new CharacterData(data);
        sprite = data.sprite;
        portrait.sprite = sprite;
        if (data.isEnemy)
        {
            Destroy(playerUI.gameObject);
            enemyUI.UpdateUI();
            button.targetGraphic = portrait;
        }
        else // is player
        {
            Destroy(enemyUI.gameObject);
            playerUI.UpdateUI();
            playerUI.setHighlight(false);
            portrait.enabled = false;
            button.targetGraphic = playerUI.background;
        }
    }

    [Button]
    public void SubtractHealth()
    {
        Debug.Log(characterData.Health);
        characterData.Health = 5;
    }

    public void Equip(IEquipable item)
    {

    }
}
