using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFloor : Tile
{
    public override Dictionary<string, bool> properties { get; set; }


    public EndFloor(int row, int column, float encounterMeterChance) : base(row, column, encounterMeterChance)
    {
        properties = new Dictionary<string, bool>();
        this.properties.Add("isFloor", true);
        this.properties.Add("isEndFloor", true);
        this.row = row;
        this.column = column;
    }
}
