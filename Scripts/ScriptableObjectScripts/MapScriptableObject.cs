using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/mapData", order = 1)]
public class MapScriptableObject : ScriptableObject
{
    public Texture2D mapLayout;
}
