using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObject/MapData", order = 1)]
public class MapData : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "Floor", ValueLabel = "Map")]
    public Dictionary<int, Texture2D> maps;
    public Dictionary<int, Texture2D> encounterChanceMap;
    public Dictionary<TileTypes, TilePallete> tiles;

    public Texture2D getMap(int floor)
    {
        if (maps[floor] == null) return null;
        return maps[floor];
    }

    public Texture2D getEncounterChanceMap(int floor)
    {
        if (encounterChanceMap[floor] == null) return null;
        return encounterChanceMap[floor];
    }
}
