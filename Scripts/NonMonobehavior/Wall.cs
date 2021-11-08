using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Tile
{
    public override Dictionary<string, bool> properties { get; set; }
    // the "new" keyword apparently hides the abstract class thing.
    public override int row { get; set; }
    public override int column  { get; set; }

    public Wall(int row, int column)
    {
        properties = new Dictionary<string, bool>();
        properties.Add("isWall", true);
        this.row = row;
        this.row = column;
    }
}
