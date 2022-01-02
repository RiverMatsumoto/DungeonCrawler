using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CharacterDataLibrary", menuName = "ScriptableObject/CharacterDataLibrary", order = 6)]
public class CharacterDataLibrary : SerializedScriptableObject
{
    public List<BattleEntity> characterDataLibrary;
}