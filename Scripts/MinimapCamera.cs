using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MinimapCamera : MonoBehaviour
{
    #region Variables
    public OverworldData overworldData;
    public MapHandler mapGenerator;
    public Camera minimapCamera;
    public RectTransform overworldMinimap;
    public RectTransform battleMinimap;
    private readonly int N_PAD = 34;
    private readonly int S_PAD = 5;
    private readonly int E_PAD = 42;
    private readonly int W_PAD = 5;
    private Vector2Int playerPosition;
    readonly Vector3 mapOpenPosition = new Vector3(24, 20, -50);
    const float cameraZOffset = -50;
    bool hitNPadding = false;
    bool hitSPadding = false;
    bool hitWPadding = false;
    bool hitEPadding = false;
    bool mapOpen = false;
    #endregion


    public void moveCamera(Vector2Int position)
    {
        if (mapOpen) { return; }

        hitNPadding = false;
        hitSPadding = false;
        hitWPadding = false;
        hitEPadding = false;

        Vector3 paddedPosition = new Vector3(0, 0, cameraZOffset);
        if (overworldData.playerPosition.x < W_PAD)
        {
            paddedPosition.x += W_PAD;
            hitWPadding = true;
        }
        if (overworldData.playerPosition.x > E_PAD)
        {
            paddedPosition.x += E_PAD;
            hitEPadding = true;
        }
        if (overworldData.playerPosition.y < S_PAD)
        {
            paddedPosition.y += S_PAD;
            hitSPadding = true;
        }
        if (overworldData.playerPosition.y > N_PAD)
        {
            paddedPosition.y += N_PAD;
            hitNPadding = true;
        }

        if ((hitNPadding || hitSPadding) && (hitWPadding || hitEPadding))
        {
            transform.localPosition = paddedPosition;
        }
        else if (hitNPadding)
        {
            transform.localPosition = new Vector3(
                overworldData.playerPosition.x,
                N_PAD,
                cameraZOffset
            );
        }
        else if (hitSPadding)
        {
            transform.localPosition = new Vector3(
                overworldData.playerPosition.x,
                S_PAD,
                cameraZOffset
            );
        }
        else if (hitWPadding)
        {
            transform.localPosition = new Vector3(
                W_PAD,
                overworldData.playerPosition.y,
                cameraZOffset
            );
        }
        else if (hitEPadding)
        {
            transform.localPosition = new Vector3(
                E_PAD,
                overworldData.playerPosition.y,
                cameraZOffset
            );
        }
        else
        {
            transform.localPosition = new Vector3(
                overworldData.playerPosition.x,
                overworldData.playerPosition.y,
                cameraZOffset
            );
        }
    }

    public void toggleMap(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (overworldData.inBattle)
            {
                toggleMapInBattle();
            }
            else
            {
                toggleMapInOverworld();
            }
        }
    }

    public void toggleMapInOverworld()
    {
        if (mapOpen)
        {
            minimizeOverworldMap();
        }
        else
        {
            maximizeOverworldMap();
        }
    }

    public void minimizeOverworldMap()
    {
        // toggles the ui position to the smaller minimap
        overworldMinimap.localPosition = new Vector3(0, 0, 0);
        overworldMinimap.localScale = Vector3.one;
        mapOpen = false;
        minimapCamera.orthographicSize = 6F;
        moveCamera(overworldData.playerPosition);
    }

    public void maximizeOverworldMap()
    {
        // toggles the ui position to the larger minimap
        overworldMinimap.localPosition = new Vector3(-200F, -70F, 0);
        overworldMinimap.localScale = new Vector3(2.5F, 2.5F, 1);
        mapOpen = true;
        transform.localPosition = mapOpenPosition;
        minimapCamera.orthographicSize = 25F;
    }

    public void toggleMapInBattle()
    {
        if (mapOpen)
        {
            minimizeBattleMap();
        }
        else
        {
            maximizeBattleMap();
        }
    }

    public void minimizeBattleMap()
    {
        battleMinimap.localPosition = new Vector3(20, 28, 0);
        battleMinimap.localScale = Vector3.one;
        mapOpen = false;
        minimapCamera.orthographicSize = 8F;
        moveCamera(overworldData.playerPosition);

    }

    public void maximizeBattleMap()
    {
        battleMinimap.localPosition = new Vector3(-190F, -50F, 0);
        battleMinimap.localScale = new Vector3(3.5F, 3.5F, 1);
        mapOpen = true;
        minimapCamera.orthographicSize = 25F;
        transform.localPosition = mapOpenPosition;
    }

    private void OnEnable()
    {
        MovementEventHandler.playerMoved += moveCamera;
        // TODO Add battle events
    }

    private void OnDisable()
    {
        MovementEventHandler.playerMoved -= moveCamera;
    }
}