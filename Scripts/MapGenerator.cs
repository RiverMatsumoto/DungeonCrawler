using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] tiles;
    public Map map;
    [SerializeField]
    private Texture2D mapLayout;
    const float TILE_SPACING = 5;
    const int FLOOR = 0;
    const int WALL = 1;

    void Awake()
    {
        map = new Map(8,8, mapLayout);
        for (int x = 0; x < map.rows; x++)
        {
            for (int y = 0; y < map.columns; y++)
            {
                if (mapLayout.GetPixel(x, y) == Color.black)
                {
                    var wallInstance = Instantiate(tiles[WALL], new Vector3(x*TILE_SPACING, 0, y*TILE_SPACING), Quaternion.identity, transform);
                }
                // if (map.tiles[x,y] is Wall)
                // {
                    
                // } 
            }
        }
    }

}
