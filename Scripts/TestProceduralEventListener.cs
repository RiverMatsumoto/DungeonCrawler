using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProceduralEventListener : MonoBehaviour
{
    public GameEventListener listener;
    public event Action OnTestEvent;
    private void Start()
    {
        
    }
}
