using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayer : MonoBehaviour
{
    private readonly Vector3 TILE_OFFSET = new Vector3(0.5F, 0.5F, -1);
    public OverworldData overworldData;


    public void movePlayer()
    {
        transform.localPosition = new Vector3(overworldData.playerPosition.x, overworldData.playerPosition.y, -1);
    }

    public void turnPlayer()
    {
        // transform.localRotation = direction;
        Quaternion targetFacingDir = transform.localRotation;
        targetFacingDir.SetLookRotation(
            Vector3.forward,
            new Vector3(overworldData.playerFacingDir.x, overworldData.playerFacingDir.y, 0)
        );
        transform.localRotation = targetFacingDir;
        
    }
}
