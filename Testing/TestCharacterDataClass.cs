using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TestCharacterDataClass : MonoBehaviour
{
    [SerializeField]
    public TestScriptableObjectEditing test;
    public CharacterDataEditor data;

    [Button]
    public void ReadData()
    {
        test = new TestScriptableObjectEditing(data);
    }
    
    [Button]
    public void SetData() => test.data = 300;
}
