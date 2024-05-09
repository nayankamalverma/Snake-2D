using Assets.Scripts.Snake;
using System.Collections.Generic;
using UnityEngine;

public class CoOpSnakeController : MonoBehaviour
{
    //snake related vars
    private Vector2Int gridPostition; //snake head grid position
    private MoveDirection gridMoveDirection; // to update position of snake in a direction
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private int snakeBodySize;
    private List<SnakeMovePosition> snakeBodyPositionList;
    private List<SnakeBodyPart> snakeBodyPartList;
    // tag 
    [SerializeField] private string objectTag;
    [SerializeField] private float SpawnPosX;
    [SerializeField] private float SpawnPosY;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;

    //other vars
    private CoOpFoodController foodController;
    private int maxBoundX;  //grid size x axis
    private int maxBoundY;  //grid size y axis


    public void Setup(CoOpFoodController foodController, int maxBoundX, int maxBoundY)
    {
        this.foodController = foodController;
        this.maxBoundX = maxBoundX;
        this.maxBoundY = maxBoundY;
    }

    private void Awake()
    {
        gridMoveTimerMax = .2f;
        gridMoveTimer = gridMoveTimerMax;
        objectTag = gameObject.tag;
        //check tag here for direcvtion
        if (objectTag == "BlueSnake")
        {
            gridMoveDirection = MoveDirection.RIGHT;
        }
        else
        {
            gridMoveDirection = MoveDirection.LEFT;
        }
        
        snakeBodyPositionList = new List<SnakeMovePosition>();
        snakeBodySize = 0;
        snakeBodyPartList = new List<SnakeBodyPart>();
        
    }

    private void Start()
    {
        if (objectTag == "BlueSnake")
        {
            gridPostition = new Vector2Int(3, 3);
        }
        else
        {
            gridPostition = new Vector2Int(maxBoundX-3, maxBoundY-3);
        }
    }
    private void Update()
    {
        HandleInput();
        HandleGridMovement();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(up))
        {
            if (gridMoveDirection != MoveDirection.DOWN)
            {
                gridMoveDirection = MoveDirection.UP;
            }
        }
        if (Input.GetKeyDown(down))
        {
            if (gridMoveDirection != MoveDirection.UP)
            {
                gridMoveDirection = MoveDirection.DOWN;
            }
        }
        if (Input.GetKeyDown(left))
        {
            if (gridMoveDirection != MoveDirection.RIGHT)
            {
                gridMoveDirection = MoveDirection.LEFT;
            }
        }
        if (Input.GetKeyDown(right))
        {
            if (gridMoveDirection != MoveDirection.LEFT)
            {
                gridMoveDirection = MoveDirection.RIGHT;
            }
        }

    }

    void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;

            SnakeMovePosition prevMovePosition = null;
            if (snakeBodyPositionList.Count > 0)
            {
                prevMovePosition = snakeBodyPositionList[0];
            }

            SnakeMovePosition snakeMovePosition = new SnakeMovePosition(gridPostition, gridMoveDirection, prevMovePosition);
            snakeBodyPositionList.Insert(0, snakeMovePosition);

            Vector2Int gridMoveDirectionVector;
            switch (gridMoveDirection)
            {
                default:
                case MoveDirection.RIGHT: gridMoveDirectionVector = new Vector2Int(1, 0); break;
                case MoveDirection.LEFT: gridMoveDirectionVector = new Vector2Int(-1, 0); break;
                case MoveDirection.UP: gridMoveDirectionVector = new Vector2Int(0, 1); break;
                case MoveDirection.DOWN: gridMoveDirectionVector = new Vector2Int(0, -1); break;

            }

            gridPostition += gridMoveDirectionVector;

            if (snakeBodyPositionList.Count >= snakeBodySize + 1)
            {
                snakeBodyPositionList.RemoveAt(snakeBodyPositionList.Count - 1);
            }
            ScreenWraping();
            transform.position = new Vector3(gridPostition.x, gridPostition.y);
            transform.eulerAngles = new Vector3(0, 0, Angle(gridMoveDirection));

            UpdateSnakeBodyPart();
        }
    }

    public void SnakeAteFood()
    {
        snakeBodySize++;
        CreateSnakeBody();
        foodController.SpawnFood();
    }

    public static float Angle(MoveDirection move)
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

    private void CreateSnakeBody()
    {
        snakeBodyPartList.Add(new SnakeBodyPart(snakeBodyPartList.Count, objectTag));
    }

    private void UpdateSnakeBodyPart()
    {
        for (int i = 0; i < snakeBodyPartList.Count; i++)
        {
            snakeBodyPartList[i].SetSnakeMovePosition(snakeBodyPositionList[i]);
        }
    }

    void ScreenWraping()
    {
        if (gridPostition.y >= maxBoundY && gridMoveDirection == MoveDirection.UP)
        {
            gridPostition.y = 1;
        }
        if (gridPostition.y <= 0 && gridMoveDirection == MoveDirection.DOWN)
        {
            gridPostition.y = maxBoundY - 1;
        }
        if (gridPostition.x >= maxBoundX && gridMoveDirection == MoveDirection.RIGHT)
        {
            gridPostition.x = 1;
        }
        if (gridPostition.x <= 0 && gridMoveDirection == MoveDirection.LEFT)
        {
            gridPostition.x = maxBoundX - 1;
        }
    }



    public Vector2Int GetGridPosition()
    {
        return gridPostition;
    }

    public List<Vector2Int> GetSnakeFullBodyPosition()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>() { gridPostition };
        foreach (SnakeMovePosition snakeMovePosition in snakeBodyPositionList)
        {
            gridPositionList.Add(snakeMovePosition.GetGridPosition());
        }
        return gridPositionList;
    }
}
