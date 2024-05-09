using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoOpFoodController : MonoBehaviour
{
    private CoOpSnakeController redSnake;
    private CoOpSnakeController blueSnake;
    private Vector2Int foodGridPosition;
    private int maxBoundX;
    private int maxBoundY;

    public void Setup(CoOpSnakeController red, CoOpSnakeController blue)
    {
        this.redSnake = red;
        this.blueSnake = blue;
        SpawnFood();
    }

    public CoOpFoodController(int maxBoundX, int maxBoundY)
    {
        this.maxBoundX = maxBoundX;
        this.maxBoundY = maxBoundY;
    }

    public void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(3, maxBoundX - 2), Random.Range(3, maxBoundY - 2));
        } while (redSnake.GetSnakeFullBodyPosition().IndexOf(foodGridPosition) != -1 && blueSnake.GetSnakeFullBodyPosition().IndexOf(foodGridPosition) != -1);

        Instantiate(GameAssets.Instance.FoodPrefab, new Vector3(foodGridPosition.x, foodGridPosition.y), Quaternion.identity);
    }
}
