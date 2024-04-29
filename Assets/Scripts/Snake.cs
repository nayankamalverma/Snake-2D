using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPostition;

    private void Awake()
    {
        gridPostition = new Vector2Int(30,20);
    }
    
}
