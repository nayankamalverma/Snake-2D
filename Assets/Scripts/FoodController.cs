using UnityEngine;

public class FoodController : MonoBehaviour
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
    
    public FoodController(int maxBoundX, int maxBoundY)
    {
        this.maxBoundX = maxBoundX;
        this.maxBoundY = maxBoundY;
    }

    public void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(3, maxBoundX - 2), Random.Range(3, maxBoundY - 2));
        } while (snake.GetSnakeFullBodyPosition().IndexOf(foodGridPosition) != -1);

        Instantiate(GameAssets.Instance.FoodPrefab, new Vector3(foodGridPosition.x, foodGridPosition.y), Quaternion.identity);
    }
}
