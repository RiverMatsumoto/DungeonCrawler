using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{

    public void moveCamera(Vector2Int position)
    {
        transform.localPosition = new Vector3(position.x, position.y, -10);
        // transform.localPosition += TILE_OFFSET;
    }

    private void OnEnable()
    {
        MovementEventHandler.broadcastPlayerMoved += moveCamera;
    }

    private void OnDisable() 
    {
        MovementEventHandler.broadcastPlayerMoved -= moveCamera;
    }
}
