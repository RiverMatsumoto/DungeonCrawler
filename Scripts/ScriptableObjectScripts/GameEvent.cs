using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Game Event", menuName = "ScriptableObject/GameEvent", order = 7)]
public class GameEvent : SerializedScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    public void raise()
    {
        for (int i = listeners.Count; i >= 0; i++)
        {
            // on event raised
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void DeregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
