using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile
{
    public abstract Dictionary<string, bool> properties { get; set; }
    public int row { get; set; }
    public int column { get; set; }
    public float encounterMeterChance { get; set; }
    public virtual void tileEffect()
    {
        // do nothing when walked on
    }

    protected Tile(int row, int column, float encounterMeterChance)
    {
        this.row = row;
        this.column = column;
        this.encounterMeterChance = encounterMeterChance;
    }
}
