using UnityEngine;

public class FoodController : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SnakeHead"))
        {
            SoundManger.Instance.Play(Sounds.FoodCollected);
            collision.gameObject.GetComponent<SnakeController>().SnakeAteFood();
            Destroy(gameObject);
        }
    }

}
