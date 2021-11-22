using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoordinates : MonoBehaviour
{

    public void updateUICoordinates(Vector2Int coordinates)
    {

        GetComponent<TMPro.TextMeshProUGUI>().text = coordinates.ToString();
    }

    private void OnEnable()
    {
        MovementEventHandler.broadCastPlayerMoved += updateUICoordinates;
    }
    
    private void OnDisable() 
    {
        MovementEventHandler.broadCastPlayerMoved -= updateUICoordinates;
    }
}
