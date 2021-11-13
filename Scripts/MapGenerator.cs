using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapGenerator : MonoBehaviour
{
    public Map map;
    public PlayerMovement player;
    [SerializeField]
    private Texture2D mapLayout;
    [SerializeField]
    private GameObject[] tiles;
    private GameObject mapObjects;
    private const int TILE_SPACING = 5;


    void Start()
    {
        mapObjects = new GameObject("MapObjects");
        // store the map texture layout rows and columns
        int columns = mapLayout.height;
        int rows = mapLayout.width;
        map = new Map(rows, columns, mapLayout);
        for (int x = -1; x < rows + 1; x++)
        {
            for (int y = -1; y < columns + 1; y++)
            {
                if (x == -1 || y == -1 || x == rows || y == columns)
                {
                    instantiateWall(x, y);
                }
                else if (map.getTile(x, y) is Wall)
                {
                    instantiateWall(x, y);
                }
            }
        }
        player.placePlayer(map.playerPosition, Map.UP);
    }

    // debugging
    public void onPlacePlayer(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("pressed L");
            player.placePlayer(new Vector2Int(30, 30), Map.DOWN);
        }
    }

    /// <summary>
    /// Helper function to spawn a wall at a given x and y coordinate.
    /// </summary>
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    private void instantiateWall(int x, int y)
    {
        GameObject wall = Instantiate
        (
                tiles[(int)TileTypes.WALL],
                new Vector3(x * TILE_SPACING, 0, y * TILE_SPACING),
                Quaternion.identity
        );
        wall.transform.parent = mapObjects.transform;
    }
}
