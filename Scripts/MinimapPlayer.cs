using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayer : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private readonly Vector3 TILE_OFFSET = new Vector3(0.5F, 0.5F, -1);


    public void movePlayer(Vector2Int position)
    {
        transform.localPosition = new Vector3(position.x, position.y, -1);
        // transform.localPosition += TILE_OFFSET;
    }
    
    public void turnPlayer(Quaternion direction)
    {
        transform.localRotation = direction;
    }

    private void OnEnable()
    {
        MovementEventHandler.broadcastPlayerMoved += movePlayer;
        MovementEventHandler.broadCastPlayerTurned += turnPlayer;
    }

    private void OnDisable() 
    {
        MovementEventHandler.broadcastPlayerMoved -= movePlayer;
        MovementEventHandler.broadCastPlayerTurned -= turnPlayer;
    }
}
