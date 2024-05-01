using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    private SnakeController snake;
    private Vector2Int foodGridPosition;
    private int maxBoundX;
    private int maxBoundY;

    public void Setup(SnakeController snake)
    {
        this.snake = snake;

       SpawnFood();
    }
    
    public LevelGrid(int maxBoundX, int maxBoundY)
    {
        this.maxBoundX = maxBoundX;
        this.maxBoundY = maxBoundY;
    }

    public void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(1, maxBoundX - 1), Random.Range(1, maxBoundY - 1));
        } while (snake.getSnakeFullBodyPosition().IndexOf(foodGridPosition) != -1);

        Instantiate(GameAssets.Instance.foodPrefab, new Vector3(foodGridPosition.x, foodGridPosition.y), Quaternion.identity);
    }
}
