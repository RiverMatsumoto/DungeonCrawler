using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinimapGenerator : MonoBehaviour
{
    public Grid minimap;
    public Tilemap tilemap;
    public ITilemap tilePallete;
    public List<TileBase> tileBase;
    public MapGenerator mapGenerator;

    void Start()
    {
        for (var x = 0; x < mapGenerator.currentMap.columns; x++)
        {
            for (var y = 0; y < mapGenerator.currentMap.rows; y++)
            {
                if (mapGenerator.currentMap.getTile(x, y) is Floor)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase[(int)TileTypes.FLOOR]);
                }
                else if (mapGenerator.currentMap.getTile(x, y) is Wall)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase[(int)TileTypes.WALL]);
                }
                else if (mapGenerator.currentMap.getTile(x, y) is StartFloor)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase[(int)TileTypes.FLOOR]);
                }
            }
        }
    }
}
