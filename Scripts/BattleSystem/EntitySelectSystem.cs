using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EntitySelectSystem : EventTrigger
{
    public static EntitySelectSystem instance;
    public delegate void selectingEnemyEvent();
    public static event selectingEnemyEvent selectingEnemy;
    public BattleEntity highlightedEntity;
    public BattleEntity target;
    public BattleCommand currentBattleCommand;
    public EntitySelector entitySelector;
    private int selectPosition;
    public SelectingType currentSelectType;
    public enum SelectingType
    {
        ENEMIES,
        ALLIES,
        ALL,
        NONE
    }



    public void selectEntity(BattleCommand battleCommand, SelectingType selectingType = SelectingType.ENEMIES)
    {
        // disable menu
        // enable selector icon which can return a battle entity
        selectingEnemy();
        currentSelectType = selectingType;
        selectPosition = 1;

        if (selectingType == SelectingType.ENEMIES)
        {
            // battleCommand.battleEntity = BattleSystem.instance.currentPlayer;
            // highlightedEntity = BattleSystem.instance.enemies.getBattleEntity(selectPosition);
            // highlightedEntity.GetComponent<Button>().Select();
            // Vector3 position = highlightedEntity.transform.position;
            // position.y += 1;
            // transform.position = position;
        }

        // selectingEnemy();
    }

    public void setTarget(BattleEntity target)
    {
        this.target = target;
    }

    public void updateSelectedEntity(BaseEventData baseEventData)
    {
        highlightedEntity = baseEventData.selectedObject.GetComponent<BattleEntity>();
        Debug.Log("navigated buttons");
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
}
