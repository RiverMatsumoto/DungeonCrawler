using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFloor : Tile
{
    public override Dictionary<string, bool> properties { get; set; }


    public StartFloor(int row, int column, float encounterMeterChance) : base (row, column, encounterMeterChance)
    {
        properties = new Dictionary<string, bool>();
        this.properties.Add("isFloor", true);
        this.properties.Add("isStartFloor", true);
        this.row = row;
        this.column = column;
    }
}
