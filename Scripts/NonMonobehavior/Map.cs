using UnityEngine;

public class Map
{
    public readonly int rows;
    public readonly int columns;
    public Tile[,] tiles;
    public ICharacter[,] characterPositions;


    public Map(int rows, int columns, Texture2D mapLayout)
    {
        this.rows = rows;
        this.columns = columns;
        tiles = new Tile[rows, columns];
        characterPositions = new ICharacter[rows, columns];
        randomMap(mapLayout);
    }

    private void randomMap(Texture2D mapLayout)
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


    public Tile getTile(Vector2Int characterPos, Vector2Int intendedMoveDir)
    {
        Vector2Int tilePos = characterPos + intendedMoveDir;
        try
        {
            return tiles[tilePos.x, tilePos.y];
        }
        catch (System.IndexOutOfRangeException ex)
        {
            Debug.Log("getTile Exception: " + ex);
            return null;
        }
    }

    public Tile getTile(int x, int y)
    {
        return tiles[x, y];
    }

    public void placeCharacter(Vector2Int position, Vector2Int direction, ICharacter character)
    {
        characterPositions[position.x, position.y] = null;
        Debug.Log(position);
        position += direction;
        Debug.Log(position);
        characterPositions[position.x, position.y] = character;
    }
}
