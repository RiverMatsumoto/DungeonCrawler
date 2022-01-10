using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "BattleEntityFactory", menuName = "ScriptableObject/BattleEntityFactory")]
public class BattleEntityFactory : SerializedScriptableObject
{
    public BattleEntity battleEntity;
    public CharacterDataProvider characterDataProvider;

    public BattleEntityFactory(CharacterDataProvider characterDataProvider)
    {
        this.characterDataProvider = characterDataProvider;
    }

    public BattleEntity createBattleEntity(EnemyType type)
    {
        var enemy = GameObject.Instantiate<BattleEntity>(battleEntity);
        enemy.setCharacterData(characterDataProvider.getEntityDataFor(type));
        

        return enemy;
    }

    private void Start()
    {
        createBattleEntity(EnemyType.Groundhog);
    }
}
