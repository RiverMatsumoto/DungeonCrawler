using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoordinates : MonoBehaviour
{
    public TMP_Text coordinatesText;
    public OverworldData overworldData;
    public void updateUICoordinates()
    {
        coordinatesText.text = new Vector2Int(
            overworldData.playerPosition.x,
            overworldData.playerPosition.y
        ).ToString();
    }

    private void Start()
    {
        coordinatesText = GetComponent<TMP_Text>();
    }
}
