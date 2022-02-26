using UnityEngine;

public enum Entity { PLAYER, FOE }
[System.Serializable]
public class Map
{
    public static readonly Vector2Int UP = Vector2Int.up;
    public static readonly Vector2Int DOWN = Vector2Int.down;
    public static readonly Vector2Int LEFT = Vector2Int.left;
    public static readonly Vector2Int RIGHT = Vector2Int.right;
    private OverworldData overworldData;
    public readonly int columns;
    public readonly int rows;
    public Tile[,] map;
    public IOccupiesTile[,] characterPositions;
    public Vector2Int playerStartPos;
    private static class TileColor
    {
        public static readonly Color FLOOR = new Color(255, 255, 255, 255);
        public static readonly Color WALL = new Color(0, 0, 0, 255);
        public static readonly Color START_FLOOR = new Color(0, 255, 0, 255);
    }


    public Map(int columns, int rows, int floor, MapData mapData)
    {
        this.columns = columns;
        this.rows = rows;
        map = new Tile[columns, rows];
        characterPositions = new IOccupiesTile[columns, rows];
        generateMap(floor, mapData);
    }

    /// <summary>
    /// Generates a map given by a Texture2D png file. The dimensions of the image determine the size of the map.
    /// Each pixel of the image represents a tile on the map, the color of each pixel represents the type of tile. 
    /// Current color representations: White(255,255,255) = Floor; Black(0,0,0) = Wall; Green(0,255,0) = Start point;
    /// Blue(0,0,255) = an end tile;
    /// 
    /// Each map also needs an encounterChanceMap where the red channel determines what percentage chance
    /// the encounter meter goes up 1 tick.
    /// </summary>
    /// <param name="mapLayout">A Texture2D png file that determines the way the map will generate.</param>
    private void generateMap(int floor, MapData mapData)
    {
        Texture2D mapLayout = mapData.getMap(floor);
        Texture2D encounterChanceMap = mapData.getEncounterChanceMap(floor);
        for (var x = 0; x < columns; x++)
        {
            for (var y = 0; y < rows; y++)
            {
                Color pixel = colorFloatToByte(mapLayout.GetPixel(x, y));
                Color encounterChancePixel = colorFloatToByte(encounterChanceMap.GetPixel(x, y));
                
                if (pixel == TileColor.FLOOR)
                {
                    map[x, y] = new Floor(x, y, encounterChancePixel.r);
                }
                else if (pixel == TileColor.WALL)
                {
                    map[x, y] = new Wall(x, y, encounterChancePixel.r);
                }
                else if (pixel == TileColor.START_FLOOR)
                {
                    map[x, y] = new StartFloor(x, y, encounterChancePixel.r);
                    playerStartPos = new Vector2Int(x, y);
                }
            }
        }
    }

    public Tile getTile(Vector2Int position)
    {
        Vector2Int tilePos = position;
        if (checkValidCoordinates(tilePos))
        {
            return map[tilePos.x, tilePos.y];
        }
        return null;
    }

    public Tile getTile(int x, int y)
    {
        if (checkValidCoordinates(new Vector2Int(x, y)))
        {
            return map[x, y];
        }
        return null;
    }

    /// <summary>
    /// Places the entity somewhere on the map's coordinates. May only place them inside the
    /// the map boundaries.
    /// </summary>
    /// <param name="startPos">Starting point of the entity.</param>
    /// <param name="facingDir">
    /// The direction/end point the entity will move to. The direction is relative to the entity 
    /// so adding x+3 and y-2 will move the entity 3 tiles local right and 2 tiles local down. 
    /// </param>
    /// <param name="entity"></param>
    public void placeCharacter(Vector2Int startPos, Vector2Int facingDir, IOccupiesTile entity)
    {
        characterPositions[startPos.x, startPos.y] = null;
        Vector2Int endPos = startPos + facingDir;
        characterPositions[endPos.x, endPos.y] = entity;
        // TODO EDIT THIS SO IT IS CLEANER WITH PLAYER MOVED EVENTS
    }

    /// <summary> /// The method isValidMove returns a boolean value depenidng on whether
    /// the intended move is valid or not.
    /// </summary>
    /// <param name="moveDir">The intended move direction the player wants to move in.</param>
    /// <returns>A boolean true if the intended move direction is legal/valid. False if the intended move is illegal/invalid.</returns>
    public bool isValidMove(Vector2Int position)
    {
        Tile tile = getTile(position);
        // Written as nested if statements to ensure no null reference exception
        if (tile != null)
        {
            if (tile.properties.ContainsKey("isFloor"))
            {
                return true;
            }
            // could also flip and only return false on walls and water and void tiles
        }
        return false;
    }

    /// <summary>
    /// Finds whether the coordinates given are within a valid range of the map.
    /// Important to use when trying to access the map coordinates.
    /// </summary>
    /// <param name="x">Map x coordinate</param>
    /// <param name="y">Map y coordinate</param>
    /// <returns>A boolean true if the coordinates are valid, false if the coordinates are invalid.</returns>
    private bool checkValidCoordinates(Vector2Int coordinates)
    {
        return !(coordinates.x >= map.GetLength(0) 
            || coordinates.x < 0
            || coordinates.y >= map.GetLength(1) 
            || coordinates.y < 0);
    }

    private void updatePlayerPosition(Vector2Int position)
    {
        playerStartPos = position;
    }

    private Color colorFloatToByte(Color pixel)
    {
        pixel.r = Mathf.RoundToInt(pixel.r * 255);
        pixel.g = Mathf.RoundToInt(pixel.g * 255);
        pixel.b = Mathf.RoundToInt(pixel.b * 255);
        pixel.a = Mathf.RoundToInt(pixel.a * 255);
        return pixel;
    }

    public void OnPlayerMoved(Vector2Int position)
    {
        
    }

    public void OnPlayerTurned(Vector2Int direction)
    {

    }

    public void OnPlayerEnteredMap()
    {
        MovementEventHandler.playerMoved += OnPlayerMoved;
        MovementEventHandler.playerTurned += OnPlayerTurned;
    }

    public void OnPlayerLeftMap()
    {
        MovementEventHandler.playerMoved -= OnPlayerMoved;
        MovementEventHandler.playerTurned -= OnPlayerTurned;
    }
}
