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
        for (var x = 0; x < mapGenerator.map.rows; x++)
        {
            for (var y = 0; y < mapGenerator.map.columns; y++)
            {
                // Tile types floor is an integer. Use integers when accessing the tilebase
                // tilemap.SetTile(new Vector3Int(0,0,0), tileBase[0]);
                // switch (mapGenerator.map.getTile(x, y).properties.ContainsKey())
                // {
                //     case :
                //         break;
                //     default:
                //         break;
                // }

                if (mapGenerator.map.getTile(x, y).GetType() == typeof(Floor))
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase[TileTypes.FLOOR]);
                }
                else if (mapGenerator.map.getTile(x, y).GetType() == typeof(Wall))
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase[TileTypes.WALL]);
                }
            }
        }
    }
}
