using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    private readonly int N_PAD = 34;
    private readonly int S_PAD = 5;
    private readonly int E_PAD = 42;
    private readonly int W_PAD = 5;
    const float cameraOffset = -50;
    public Vector2Int mapPosition;
    bool hitNPadding = false;
    bool hitSPadding = false;
    bool hitWPadding = false;
    bool hitEPadding = false;
    public void moveCamera(Vector2Int position)
    {
        hitNPadding = false;
        hitSPadding = false;
        hitWPadding = false;
        hitEPadding = false;

        Vector3 paddedPosition = new Vector3(0, 0, cameraOffset);
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
            transform.localPosition = new Vector3(position.x, N_PAD, cameraOffset);
        }
        else if (hitSPadding)
        {
            transform.localPosition = new Vector3(position.x, S_PAD, cameraOffset);
        }
        else if (hitWPadding)
        {
            transform.localPosition = new Vector3(W_PAD, position.y, cameraOffset);
        }
        else if (hitEPadding)
        {
            transform.localPosition = new Vector3(E_PAD, position.y, cameraOffset);
        }
        else
        {
            transform.localPosition = new Vector3(position.x, position.y, cameraOffset);
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
