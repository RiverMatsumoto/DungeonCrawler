using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObject/MapData", order = 1)]
public class MapData : SerializedScriptableObject
{
    public Dictionary<TileTypes, TilePallete> tiles;
}
