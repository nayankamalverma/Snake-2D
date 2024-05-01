using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    private Snake snake;
    private Vector2Int foodGridPosition;
    private GameObject food;
    private int maxBoundX;
    private int maxBoundY;

    public void Setup(Snake snake)
    {
        this.snake = snake;

        SpawnFood();
    }
    public LevelGrid(int maxBoundX, int maxBoundY)
    {
        this.maxBoundX = maxBoundX;
        this.maxBoundY = maxBoundY;
    }

    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(1, maxBoundX - 1), Random.Range(1, maxBoundY - 1));
        } while (snake.getSnakeFullBodyPosition().IndexOf(foodGridPosition) !=-1);

        food = new GameObject("food", typeof(SpriteRenderer));
        food.GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.food;
        food.layer = 7;
        food.AddComponent<FoodController>();
        CircleCollider2D collider = food.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;
        collider.radius = 0.3519378f;
        collider.offset = new Vector2(0, -0.04f);
        food.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    public bool SnakeAteFood(Vector2Int snakeGridPosition)
    {
        if(snakeGridPosition== foodGridPosition)
        {
            Object.Destroy(food);
            SpawnFood();
            return true;
        }
        return false;
    }
}
