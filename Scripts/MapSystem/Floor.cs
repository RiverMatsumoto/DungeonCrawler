using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Tile
{
    public override Dictionary<string, bool> properties { get; set; }


    public Floor(int row, int column, float encounterMeterChance) : base(row, column, encounterMeterChance)
    {
        properties = new Dictionary<string, bool>();
        properties.Add("isFloor", true);
    }
}
