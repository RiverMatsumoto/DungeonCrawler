using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class GameEventListener : SerializedMonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent response;

    public void onEventRaised()
    {
        response.Invoke();
    }

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.DeregisterListener(this);
    }
}
