using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "OverworldData", menuName = "ScriptableObject/OverworldData", order = 4)]
public class OverworldData : SerializedScriptableObject
{
    public Vector2Int playerPosition; // player position range should be inclusive from 0 to 47 for x and 0 to 39 for y
    public Vector2Int playerFacingDir; // facing direction range should be inclusive from -1 to 1
    public Vector2Int[] foePositions; // player position range should be inclusive from 0 to 47 for x and 0 to 39 for y
    public int floor;
    public int currentSteps;
    public int encounterSteps;
    public bool inBattle;
}
