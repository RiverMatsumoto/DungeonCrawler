using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

[CreateAssetMenu(fileName = "OverworldData", menuName = "ScriptableObject/OverworldData", order = 3)]
public class OverworldData : SerializedScriptableObject
{
    public Vector2Int playerPosition; // player position range should be inclusive from 0 to 47 for x and 0 to 39 for y
    public Vector2Int playerFacingDir; // facing direction range should be inclusive from -1 to 1
    public Vector2[] foePositions; // player position range should be inclusive from 0 to 47 for x and 0 to 39 for y

}
