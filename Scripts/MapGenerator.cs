using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapGenerator : MonoBehaviour
{
    public Map currentMap;
    public MapData mapData;
    public OverworldData overworldData;
    public PlayerMovement player;
    [SerializeField]
    private Texture2D[] mapLayout;
    private GameObject mapObjects;
    private const int TILE_SPACING = 5;


    void Start()
    {
        generateMap(0);
    }

    private void generateMap(int mapIndex)
    {
        Destroy(GameObject.Find("MapObjects"));
        
        mapObjects = new GameObject("MapObjects");
        // store the map texture layout rows and columns
        int columns = mapLayout[mapIndex].height;
        int rows = mapLayout[mapIndex].width;
        currentMap = new Map(rows, columns, mapLayout[mapIndex]);
        for (int x = -1; x < currentMap.rows + 1; x++)
        {
            for (int y = -1; y < currentMap.columns + 1; y++)
            {
                if (x == -1 || y == -1 || x == currentMap.rows || y == currentMap.columns)
                {
                    instantiateWall(x, y);
                }
                else if (currentMap.getTile(x, y) is Wall)
                {
                    instantiateWall(x, y);
                }
            }
        }
        player.placePlayer(currentMap.playerPosition, Map.UP);
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
                mapData.tiles[TileTypes.WALL].model,
                new Vector3(x * TILE_SPACING, 0, y * TILE_SPACING),
                Quaternion.identity
        );
        wall.transform.parent = mapObjects.transform;
    }
}
