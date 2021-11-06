using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Tile
{
    // the "new" keyword apparently hides the abstract class thing.
    public override bool isFloor { get; set;}
    public override int row { get; set; }
    public override int column  { get; set; }

    public Wall(int row, int column)
    {
        this.isFloor = false;
        this.row = row;
        this.row = column;
    }
}
