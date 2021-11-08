using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFloor : Tile
{
    public override bool isFloor { get; set; }
    public override int row { get; set; }
    public override int column { get; set; }

    public StartFloor(int row, int column)
    {
        this.isFloor = true;
        this.row = row;
        this.column = column;
    }
}
