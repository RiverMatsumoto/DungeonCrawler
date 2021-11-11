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
        for (var x = 0; x < mapGenerator.map.columns; x++)
        {
            for (var y = 0; y < mapGenerator.map.rows; y++)
            {
                if (mapGenerator.map.getTile(x, y) is Floor)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase[(int)TileTypes.FLOOR]);
                }
                else if (mapGenerator.map.getTile(x, y) is Wall)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase[(int)TileTypes.WALL]);
                }
                else if (mapGenerator.map.getTile(x, y) is StartFloor)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase[(int)TileTypes.FLOOR]);
                }
            }
        }
    }
}
