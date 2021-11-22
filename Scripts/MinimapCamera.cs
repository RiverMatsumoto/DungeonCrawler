using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MinimapCamera : MonoBehaviour
{
    public OverworldData overworldData;
    public MapGenerator mapGenerator;
    public Camera minimapCamera;
    public RectTransform UIMinimap;
    private readonly int N_PAD = 34;
    private readonly int S_PAD = 5;
    private readonly int E_PAD = 42;
    private readonly int W_PAD = 5;
    const float cameraZOffset = -50;
    private Vector2Int playerPosition;
    readonly Vector3 mapOpenPosition = new Vector3(24,20, -50);
    bool hitNPadding = false;
    bool hitSPadding = false;
    bool hitWPadding = false;
    bool hitEPadding = false;
    bool mapOpen = false;

    public void moveCamera(Vector2Int position)
    {
        playerPosition = position; // always refresh the player's mapPosition
        if (mapOpen) { return; }

        hitNPadding = false;
        hitSPadding = false;
        hitWPadding = false;
        hitEPadding = false;

        Vector3 paddedPosition = new Vector3(0, 0, cameraZOffset);
        if (position.x < W_PAD)
        {
            paddedPosition.x += W_PAD;
            hitWPadding = true;
        }
        if (position.x > E_PAD)
        {
            paddedPosition.x += E_PAD;
            hitEPadding = true;
        }
        if (position.y < S_PAD)
        {
            paddedPosition.y += S_PAD;
            hitSPadding = true;
        }
        if (position.y > N_PAD)
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
            transform.localPosition = new Vector3(position.x, N_PAD, cameraZOffset);
        }
        else if (hitSPadding)
        {
            transform.localPosition = new Vector3(position.x, S_PAD, cameraZOffset);
        }
        else if (hitWPadding)
        {
            transform.localPosition = new Vector3(W_PAD, position.y, cameraZOffset);
        }
        else if (hitEPadding)
        {
            transform.localPosition = new Vector3(E_PAD, position.y, cameraZOffset);
        }
        else
        {
            transform.localPosition = new Vector3(position.x, position.y, cameraZOffset);
        }
    }

    public void toggleMap(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (mapOpen)
            {
                setUITransform();
                mapOpen = false;
                minimapCamera.orthographicSize = 6F;
                moveCamera(playerPosition);
            }
            else
            {
                setUITransform();
                mapOpen = true;
                transform.localPosition = mapOpenPosition;
                minimapCamera.orthographicSize = 25F;
            }
        }
    }

    private void setUITransform()
    {
        if (mapOpen)
        {
            UIMinimap.localPosition = new Vector3(0, 0, 0);
            UIMinimap.localScale = Vector3.one;
        } 
        else
        {
            UIMinimap.localPosition = new Vector3(-190F, -50F, 0);
            UIMinimap.localScale = new Vector3(2.5F, 2.5F, 1);
        }
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
