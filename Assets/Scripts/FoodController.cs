using UnityEngine;

public class FoodController : MonoBehaviour
{
    
    private void Start()
    {
        Debug.Log("start");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SnakeHead"))
        {
            collision.gameObject.GetComponent<SnakeController>().SnakeAteFood();
            Destroy(gameObject);
        }
    }

}
