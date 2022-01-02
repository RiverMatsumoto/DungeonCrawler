using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoordinates : MonoBehaviour
{
    public TMP_Text coordinatesText;
    public void updateUICoordinates(Vector2Int coordinates)
    {

        coordinatesText.text = coordinates.ToString();
    }

    private void OnEnable()
    {
        MovementEventHandler.broadcastPlayerMoved += updateUICoordinates;
    }

    private void OnDisable()
    {
        MovementEventHandler.broadcastPlayerMoved -= updateUICoordinates;
        
    }

    private void Start()
    {
        coordinatesText = GetComponent<TMP_Text>();
    }
}
