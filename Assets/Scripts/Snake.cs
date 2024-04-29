using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPostition;
    private Vector2Int gridMoveDirection;
    private float gridMoveTimer;
    private float gridMoveTimerMax;

    private void Awake()
    {
        gridPostition = new Vector2Int(30, 20);
        gridMoveTimerMax = .2f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
    }

    private void Update()
    {
        InputHandler();
        GridMovementHandler();
    }

    void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           if(gridMoveDirection.y!=-1){
                gridMoveDirection.x = 0;
                gridMoveDirection.y = 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if( Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != 1){
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
        if( Input.GetKeyDown (KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1){
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
            }
        }

    }

    void GridMovementHandler()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridPostition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;

            transform.position = new Vector3(gridPostition.x, gridPostition.y);
            transform.eulerAngles = new Vector3(0, 0, HeadRotation(gridMoveDirection));
        }
    }

    private float HeadRotation(Vector2Int gridMoveDirection)
    {                                                                       // directions
        if(gridMoveDirection.x == 0 && gridMoveDirection.y ==1 )return 0f;   // up
        if( gridMoveDirection.x == 0 && gridMoveDirection.y == -1 )return 180f;// down
        if( gridMoveDirection.x == 1 && gridMoveDirection.y != 0 )return 270f; // right
        return 90f; // left
    }
}
