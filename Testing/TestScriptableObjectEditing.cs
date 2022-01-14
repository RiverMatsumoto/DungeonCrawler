using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestScriptableObjectEditing
{
    public int data;

    public TestScriptableObjectEditing(CharacterData data)
    {
        this.data = data.strength;
    }
}
