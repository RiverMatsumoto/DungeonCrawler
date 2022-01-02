using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "TileData", menuName = "ScriptableObject/TileData", order = 2)]
public class TilePallete : ScriptableObject
{
    public GameObject model;
    public Texture2D minimapTexture;
    public TileTypes tileType;

}
