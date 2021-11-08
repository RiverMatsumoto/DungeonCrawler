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
        // store the map texture layout rows and columns
        int rows = mapLayout.height;
        int columns = mapLayout.width;
        map = new Map(rows, columns, mapLayout);
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
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
