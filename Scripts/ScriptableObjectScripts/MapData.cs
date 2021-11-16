using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObject/MapData")]
public class MapData : ScriptableObject
{
    [ShowInInspector]
    public Dictionary<TileTypes, TilePallete> tiles;
}
