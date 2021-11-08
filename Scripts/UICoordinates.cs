using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoordinates : MonoBehaviour
{
    public PlayerMovement player;
    private void FixedUpdate() 
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = player.mapPosition.ToString();
    }
}
