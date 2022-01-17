using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayer : MonoBehaviour
{
    private readonly Vector3 TILE_OFFSET = new Vector3(0.5F, 0.5F, -1);
    public OverworldData overworldData;


    public void OnPlayerMoved(Vector2Int position)
    {
        transform.localPosition = new Vector3(position.x, position.y, -1);
    }

    public void OnPlayerTurned(Vector2Int playerLocalForward)
    {
        // transform.localRotation = direction;
        Quaternion targetFacingDir = transform.localRotation;
        targetFacingDir.SetLookRotation(
            Vector3.forward,
            new Vector3(playerLocalForward.x, playerLocalForward.y, 0) 
        );
        transform.localRotation = targetFacingDir;

    }

    private void OnEnable()
    {
        MovementEventHandler.playerMoved += OnPlayerMoved;
        MovementEventHandler.playerTurned += OnPlayerTurned;
    }

    private void OnDisable()
    {

        MovementEventHandler.playerMoved -= OnPlayerMoved;
        MovementEventHandler.playerTurned -= OnPlayerTurned;
    }
}
