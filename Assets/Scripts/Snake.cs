using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPostition;
    private Vector2Int gridMoveDirection;
    private MoveDirection moveDirection;
    private float gridMoveTimer;
    private float gridMoveTimerMax;

    private readonly int maxBoundX = 60;
    private readonly int maxBoundY = 40;

    private void Awake()
    {
        gridPostition = new Vector2Int(30, 20);
        gridMoveTimerMax = .2f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
        moveDirection = MoveDirection.RIGHT;
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
           if(moveDirection!=MoveDirection.DOWN){
                gridMoveDirection.x = 0;
                gridMoveDirection.y = 1;
                moveDirection = MoveDirection.UP;
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (moveDirection!=MoveDirection.UP)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
                moveDirection = MoveDirection.DOWN;
            }
        }
        if( Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (moveDirection != MoveDirection.RIGHT)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
                moveDirection = MoveDirection.LEFT;
            }
        }
        if( Input.GetKeyDown (KeyCode.RightArrow))
        {
            if (moveDirection != MoveDirection.LEFT)
            {
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
                moveDirection = MoveDirection.RIGHT;
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

            ScreenWraping();

            transform.position = new Vector3(gridPostition.x, gridPostition.y);
            transform.eulerAngles = new Vector3(0, 0, HeadRotation(moveDirection));
        }
    }

    void ScreenWraping()
    {
        if(gridPostition.y >= maxBoundY && moveDirection == MoveDirection.UP)
        {
            gridPostition.y = 1;
        }
        if (gridPostition.y <= 0 &&  moveDirection == MoveDirection.DOWN)
        {
            gridPostition.y = maxBoundY - 1;
        }
        if(gridPostition.x >= maxBoundX && moveDirection == MoveDirection.RIGHT)
        {
            gridPostition.x = 1;
        }
        if(gridPostition.x <= 0 && moveDirection == MoveDirection.LEFT)
        {
            gridPostition.x = maxBoundX - 1;
        }
    }

    private float HeadRotation(MoveDirection move)
    {
        switch (move)
        {
            case MoveDirection.LEFT: return 90f;
            case MoveDirection.RIGHT: return 270f;
            case MoveDirection.DOWN: return 180f;
            case MoveDirection.UP: return 0f;
            default: return 0f;
        }
    }
}
