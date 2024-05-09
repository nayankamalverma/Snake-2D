using Assets.Scripts.Snake;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    //snake related vars
    private Vector2Int gridPostition; //snake head grid position
    private MoveDirection gridMoveDirection; // to update position of snake in a direction
    private float gridMoveTimer; 
    private float gridMoveTimerMax;
    [SerializeField]  private int snakeBodySize;
    private List<SnakeMovePosition> snakeBodyPositionList;
    private List<SnakeBodyPart> snakeBodyPartList;
    [SerializeField] private ScoreController scoreController;

    //other vars
    private FoodController foodController;
    private int maxBoundX;  //grid size x axis
    private int maxBoundY;  //grid size y axis

    public void Setup(FoodController levelGrid, int maxBoundX,int maxBoundY)
    {
        this.foodController = levelGrid;
        this.maxBoundX = maxBoundX;
        this.maxBoundY = maxBoundY;
    }

    private void Awake()
    {
        gridMoveTimerMax = .2f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = MoveDirection.RIGHT;
        snakeBodyPositionList = new List<SnakeMovePosition>();
        snakeBodySize = 0;
        snakeBodyPartList = new List<SnakeBodyPart>();
    }

    private void Start()
    {
        gridPostition = new Vector2Int(maxBoundX / 2, maxBoundY / 2);
    }
    private void Update()
    {
        
        HandleInput();
        HandleGridMovement();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           if(gridMoveDirection != MoveDirection.DOWN){
                gridMoveDirection = MoveDirection.UP;
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection != MoveDirection.UP)
            {
                gridMoveDirection = MoveDirection.DOWN;
            }
        }
        if( Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection != MoveDirection.RIGHT)
            {
                gridMoveDirection = MoveDirection.LEFT;
            }
        }
        if( Input.GetKeyDown (KeyCode.RightArrow))
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
        {   gridMoveTimer -= gridMoveTimerMax;

            SnakeMovePosition prevMovePosition =null;
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
                case MoveDirection.RIGHT: gridMoveDirectionVector = new Vector2Int(1,0); break;
                case MoveDirection.LEFT: gridMoveDirectionVector = new Vector2Int(-1,0); break;
                case MoveDirection.UP: gridMoveDirectionVector = new Vector2Int(0,1); break;
                case MoveDirection.DOWN: gridMoveDirectionVector = new Vector2Int(0,-1); break;

            }

            gridPostition += gridMoveDirectionVector;

            if(snakeBodyPositionList.Count >= snakeBodySize + 1)
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
        scoreController.IncreaseScore(10);
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

    private void CreateSnakeBody() {
        snakeBodyPartList.Add(new SnakeBodyPart(snakeBodyPartList.Count));
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
        if(gridPostition.y >= maxBoundY && gridMoveDirection == MoveDirection.UP)
        {
            gridPostition.y = 1;
        }
        if (gridPostition.y <= 0 && gridMoveDirection == MoveDirection.DOWN)
        {
            gridPostition.y = maxBoundY - 1;
        }
        if(gridPostition.x >= maxBoundX && gridMoveDirection == MoveDirection.RIGHT)
        {
            gridPostition.x = 1;
        }
        if(gridPostition.x <= 0 && gridMoveDirection == MoveDirection.LEFT)
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
        foreach(SnakeMovePosition snakeMovePosition in snakeBodyPositionList)
        {
            gridPositionList.Add(snakeMovePosition.GetGridPosition());
        }
        return gridPositionList;
    }

}
