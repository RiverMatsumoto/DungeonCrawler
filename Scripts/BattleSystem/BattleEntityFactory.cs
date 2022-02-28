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

    public BattleEntity createEnemy(EnemyType type)
    {
        var enemy = GameObject.Instantiate<BattleEntity>(battleEntity);
        enemy.setCharacterData(characterDataProvider.getEntityDataFor(type));
        return enemy;
    }

    public BattleEntity createPlayer(CharacterDataEditor data)
    {
        //TODO CREATE NEW PLAYERS BY READING SCRIPTABLE OBJECTS DATA CREATED BY PLAYER FROM GUILD HALL. FOR NOW JUST CREATE NEW ENTITIES
        var player = GameObject.Instantiate<BattleEntity>(battleEntity);
        player.setCharacterData(data);
        return player;
    }

    private void Start()
    {
        createEnemy(EnemyType.Groundhog);
    }
}
