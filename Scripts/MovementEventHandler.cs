using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementEventHandler
{
    public delegate void playerMovedEvent(Vector2Int position);
    public static event playerMovedEvent broadcastPlayerMoved;
    public delegate void playerTurnedEvent(Quaternion direction);
    public static event playerTurnedEvent broadCastPlayerTurned;

    public static void playerMoved(Vector2Int position)
    {
        broadcastPlayerMoved(position);
    }

    public static void playerTurned(Quaternion direction)
    {
        broadCastPlayerTurned(direction);
    }

    public static Quaternion quaternionTo2D(Quaternion quaternion)
    {
        return new Quaternion(quaternion.x, quaternion.z, -quaternion.y, quaternion.w);
    }
}
