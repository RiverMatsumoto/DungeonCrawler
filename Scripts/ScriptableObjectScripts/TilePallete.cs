using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "ScriptableObject/MapData", order = 1)]
public class TilePallete : ScriptableObject
{
    public GameObject wall;
    public Texture2D minimapTexture;
    public TileTypes tileType;
}
