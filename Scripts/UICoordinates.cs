using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoordinates : MonoBehaviour
{
    public TMP_Text coordinatesText;
    public void updateUICoordinates(Vector2Int position)
    {
        coordinatesText.text = new Vector2Int(
            position.x,
            position.y
        ).ToString();
    }

    private void OnPlayerMoved(Vector2Int position) => updateUICoordinates(position);

    private void Start()
    {
        coordinatesText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        MovementEventHandler.playerMoved += OnPlayerMoved;
    }

    private void OnDisable()
    {
        MovementEventHandler.playerMoved -= OnPlayerMoved;
    }
}
