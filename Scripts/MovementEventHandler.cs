using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementEventHandler
{
    public delegate void playerMovedEvent(Vector2Int position);
    public static event playerMovedEvent playerMoved;
    public delegate void playerMoveEndedEvent();
    public static event playerMoveEndedEvent playerMoveEnded;
    public delegate void playerTurnedEvent(Vector2Int direction);
    public static event playerTurnedEvent playerTurned;

    public static void broadcastPlayerMoved(Vector2Int position) => playerMoved?.Invoke(position);

    public static void broadcastPlayerTurned(Vector2Int direction) => playerTurned?.Invoke(direction);
    
    public static void broadcastPlayerMoveEnded() => playerMoveEnded?.Invoke();
}
