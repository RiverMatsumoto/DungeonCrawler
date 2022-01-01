using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldDataHandler : MonoBehaviour
{
    // updates the overworlddata scriptable object 
    public OverworldData overworldData;

    private void Start()
    {
        overworldData.inBattle = false;
    }

    public void updatePlayerPosition(Vector2Int mapPosition)
    {
        overworldData.playerPosition = mapPosition;
    }

    public void updatePlayerFacing(Quaternion direction, Vector2Int direction2D)
    {
        overworldData.playerFacingDir = direction2D;
    }

    private void OnEnable()
    {
        MovementEventHandler.broadCastPlayerMoved += updatePlayerPosition;
        MovementEventHandler.broadCastPlayerTurned += updatePlayerFacing;
    }

    private void OnDisable()
    {
        MovementEventHandler.broadCastPlayerMoved -= updatePlayerPosition;
        MovementEventHandler.broadCastPlayerTurned -= updatePlayerFacing;
    }
}
