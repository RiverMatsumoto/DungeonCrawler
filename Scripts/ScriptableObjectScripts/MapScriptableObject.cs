using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/testData", order = 10)]
public class MapScriptableObject : ScriptableObject
{
    public Texture2D mapLayout;
}
