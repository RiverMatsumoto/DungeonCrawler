using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldDataHandler : MonoBehaviour
{
    public OverworldData overworldData;
    public void updatePlayerPosition(Vector2Int mapPosition)
    {
        overworldData.playerPosition = mapPosition;
    }

    public void updatePlayerFacing(Quaternion direction, Vector2Int direction2D)
    {
        overworldData.playerFacingDir = direction2D;
    }


    private void Start() 
    {
        MovementEventHandler.broadCastPlayerMoved += updatePlayerPosition;
        MovementEventHandler.broadCastPlayerTurned += updatePlayerFacing;
    }
}
