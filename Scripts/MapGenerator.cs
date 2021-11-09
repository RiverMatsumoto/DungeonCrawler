using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] tiles;
    public Map map;
    [SerializeField]
    private Texture2D mapLayout;
    public PlayerMovement player;
    const int TILE_SPACING = 5;
    const int FLOOR = 0;
    const int WALL = 1;
    

    void Start()
    {
        // store the map texture layout rows and columns
        int rows = mapLayout.width;
        int columns = mapLayout.height;
        map = new Map(rows, columns, mapLayout);
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                if (map.getTile(x, y) is Wall)
                {
                    var wallInstance = Instantiate(tiles[WALL], new Vector3(x*TILE_SPACING, 0, y*TILE_SPACING), Quaternion.identity, transform);
                    
                }
            }
        }
        buildPerimeter();
        player.placePlayer(Map.playerPosition, Map.UP);
    }

    // debugging
    public void onPlacePlayer(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("pressed L");
            player.placePlayer(new Vector2Int(30,30), Map.DOWN);
        }
    }

    /// <summary>
    /// Builds the perimeter around the map.
    /// </summary>
    private void buildPerimeter()
    {
        //spawn a wall around the perimeter
        for (var x = -1; x < map.rows+1; x++)
        {
            for (var y = -1; y < map.columns+1; y++)
            {
                if (x == -1 || y == -1 || x == map.rows || y == map.columns)
                {
                    instantiateWall(x,y);
                }
            }
        }
    }

    /// <summary>
    /// Helper function to spawn a wall at a given x and y coordinate.
    /// </summary>
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    private void instantiateWall(int x, int y)
    {
        var wallInstance = 
            Instantiate(
                tiles[WALL], 
                new Vector3(x*TILE_SPACING, 0, y*TILE_SPACING), 
                Quaternion.identity, 
                transform
            );
    }
}
