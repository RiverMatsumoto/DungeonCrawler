using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile
{
    public abstract Dictionary<string, bool> properties { get; set; }
    public abstract int row { get; set; }
    public abstract int column { get; set; }
}
