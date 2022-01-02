using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObject/SceneData", order = 3)]
public class SceneData : SerializedScriptableObject
{
    public enum SceneType
    {
        OVERWORLD = 0,
        BATTLE
    }
    public Scene currentScene;
    public Dictionary<SceneType, Scene>  Scenes;
}
