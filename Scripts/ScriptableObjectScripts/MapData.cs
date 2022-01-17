using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObject/MapData", order = 1)]
public class MapData : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "Floor", ValueLabel = "Map")]
    public Dictionary<int, Texture2D> maps;
    public Dictionary<TileTypes, TilePallete> tiles;

    public Texture2D getMap(int floor)
    {
        return maps[floor];
    }
}
