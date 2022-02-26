using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Tile
{
    public override Dictionary<string, bool> properties { get; set; }


    public Wall(int row, int column, float encounterMeterChance) : base(row, column, encounterMeterChance)
    {
        properties = new Dictionary<string, bool>();
        properties.Add("isWall", true);
    }
}
