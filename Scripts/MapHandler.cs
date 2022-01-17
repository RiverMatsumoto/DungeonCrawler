using UnityEngine;
using UnityEngine.InputSystem;

public class MapHandler : MonoBehaviour
{
    public Map currentMap;
    public MapData mapData;
    public OverworldData overworldData;
    public PlayerMovement player;
    public int floorNumber;
    [SerializeField]
    private Texture2D[] floorLayout;
    private GameObject mapObjects;
    private const int TILE_SPACING = 5;

    void Start()
    {
        floorNumber = 1;
        generateMap(floorNumber);
    }

    /// <summary>
    /// Generates a map based on an image. Certain colors on the image determine certain tiles.
    /// Calls the Map class constructor.
    /// </summary>
    /// <param name="floor">The index of the floorLayout image array.</param>
    private void generateMap(int floor)
    {
        Destroy(GameObject.Find("MapObjects"));
        
        mapObjects = new GameObject("MapObjects");
        // store the map texture layout rows and columns
        // int columns = floorLayout[floorLayoutIndex].height;
        // int rows = floorLayout[floorLayoutIndex].width;
        int columns = mapData.getMap(floor).height;
        int rows = mapData.getMap(floor).width;
        currentMap = new Map(rows, columns, mapData.getMap(floor));
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
        player.placePlayer(currentMap.playerStartPos, Map.UP);
    }

    /// <summary>
    /// Debugging.
    /// </summary>
    /// <param name="context">Context of the controller input</param>
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
