using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Tile
{
    public override Dictionary<string, bool> properties { get; set; }
    public override int row { get; set; }
    public override int column  { get; set; }

    public Floor(int row, int column)
    {
        properties = new Dictionary<string, bool>();
        properties.Add("isFloor", true);
        this.row = row;
        this.column = column;
    }
}
