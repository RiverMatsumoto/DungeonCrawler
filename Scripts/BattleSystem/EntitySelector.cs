using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntitySelector : MonoBehaviour
{
    public BattleCommand currentBattleCommand;
    private BattleEntity currentPartyMember;
    private BattleEntity currentSelectedEntity;
    private bool isSelectingEntity;


    public void navigateEntities()
    {
        // Enable the entity selector and navigate enemies
        Debug.Log("Navigating Entities");
        gameObject.SetActive(true);
        currentSelectedEntity = BattleSystem.instance.enemies.getBattleEntity(1);
        // currentSelectedEntity.GetComponent<Button>().Select();
    }

    public void selectEntity()
    {
        EntitySelectSystem.instance.setTarget(currentSelectedEntity);
    }

    private void Update()
    {
    }
}