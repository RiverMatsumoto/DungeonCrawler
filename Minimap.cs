using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public BoxCollider2D playerIcon;
    const float magnitude = 4.5F;

    private void FixedUpdate() 
    {
        //TODO CREATE A SYSTEM WHERE PLAYER ICON MOVES ON THE MINIMAP
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        transform.position = other.gameObject.transform.position;
    }
}
