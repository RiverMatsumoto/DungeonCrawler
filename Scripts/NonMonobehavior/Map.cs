using UnityEngine;

public class Map
{
    public readonly Vector2Int UP;
    public readonly Vector2Int DOWN;
    public readonly Vector2Int LEFT;
    public readonly Vector2Int RIGHT;
    public readonly int rows;
    public readonly int columns;
    public Tile[,] tiles;
    public IOccupiesTile[,] characterPositions;


    public Map(int rows, int columns, Texture2D mapLayout)
    {
        UP = Vector2Int.up;
        DOWN = Vector2Int.down;
        LEFT = Vector2Int.left;
        RIGHT = Vector2Int.right;
        this.rows = rows;
        this.columns = columns;
        tiles = new Tile[rows, columns];
        characterPositions = new IOccupiesTile[rows, columns];
        generateMap(mapLayout);
    }

    /// <summary>
    /// Generates a map given by a Texture2D png file. The dimensions of the image determine the size of the map.
    /// Each pixel of the image represents a tile on the map, the color of each pixel represents the type of tile. 
    /// </summary>
    /// <param name="mapLayout">A Texture2D png file that determines the way the map will generate.</param>
    private void generateMap(Texture2D mapLayout)
    {
        for (var x = 0; x < rows; x++)
        {
            for (var y = 0; y < columns; y++)
            {
                if (mapLayout.GetPixel(x,y) == Color.white)
                {
                    tiles[x, y] = new Floor(x, y);
                }
                else
                {
                    tiles[x, y] = new Wall(x, y);
                }
            }
        }
    }


    /// <summary>
    /// takes in coordinates on the map, and the intended move direction then returns
    /// a Tile object. 
    /// </summary>
    /// <param name="coordinates"></param>
    /// <param name="intendedMoveDir"></param>
    /// <returns></returns>
    public Tile getTile(Vector2Int coordinates, Vector2Int intendedMoveDir)
    {
        Vector2Int tilePos = coordinates + intendedMoveDir;
        if (isValidCoordinates(tilePos))
        {
            return null;
        }
        

        return tiles[tilePos.x, tilePos.y];
    }

    public Tile getTile(int x, int y)
    {
        return tiles[x, y];
    }

    /// <summary>
    /// Places the character somewhere on the map's coordinates. May only place them inside the
    /// the map boundaries.
    /// </summary>
    /// <param name="position">Starting point of </param>
    /// <param name="direction"></param>
    /// <param name="entity"></param>
    public void placeCharacter(Vector2Int position, Vector2Int direction, IOccupiesTile entity)
    {
        characterPositions[position.x, position.y] = null;
        Debug.Log(position);
        position += direction;
        Debug.Log(position);
        characterPositions[position.x, position.y] = entity;
    }

    /// <summary>
    /// Finds whether the coordinates given are within a valid range of the map.
    /// Important to use when trying to access the map coordinates.
    /// </summary>
    /// <param name="x">Map x coordinate</param>
    /// <param name="y">Map y coordinate</param>
    /// <returns>A boolean true if the coordinates are valid, false if the coordinates are invalid.</returns>
    private bool isValidCoordinates(Vector2Int coordinates)
    {
        return coordinates.x >= this.columns 
            || coordinates.x<0 
            || coordinates.y >= this.rows 
            || coordinates.y < 0;
    }
}
