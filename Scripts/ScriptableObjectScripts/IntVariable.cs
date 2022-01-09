using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Int Variable", menuName = "ScriptableObject/IntVariable")]
public class IntVariable : SerializedScriptableObject
{
    public int value;
}
