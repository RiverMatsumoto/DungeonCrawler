using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementEventHandler
{
    public delegate void playerMovedEvent(Vector2Int position);
    public static event playerMovedEvent broadcastPlayerMoved;
    public delegate void playerMoveEndedEvent();
    public static event playerMoveEndedEvent broadcastPlayerMoveEnded;
    public delegate void playerTurnedEvent(Quaternion direction, Vector2Int direction2D);
    public static event playerTurnedEvent broadCastPlayerTurned;
    // public delegate void playerTurnedEventV2Int(Vector2Int facingDir);
    // public static event playerTurnedEventV2Int broadCastPlayerTurnedV2Int;

    public static void playerMoved(Vector2Int position)
    {
        broadcastPlayerMoved(position);
    }

    public static void playerTurned(Quaternion direction, Vector2Int direction2D)
    {
        broadCastPlayerTurned(direction, direction2D);
    }
    
    public static void playerMoveEnded()
    {
        broadcastPlayerMoveEnded();
    }


    public static Quaternion quaternionTo2D(Quaternion quaternion)
    {
        return new Quaternion(quaternion.x, quaternion.z, -quaternion.y, quaternion.w);
    }
}
