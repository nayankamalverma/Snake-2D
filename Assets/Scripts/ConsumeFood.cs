using UnityEngine;

public class ConsumeFood : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string objectTag = collision.gameObject.tag; 
        if (objectTag == "SnakeHead" || objectTag == "BlueSnake" || objectTag == "RedSnake")
        {
            SoundManger.Instance.Play(Sounds.FoodCollected);
            if(objectTag == "SnakeHead") collision.gameObject.GetComponent<SnakeController>().SnakeAteFood();
            else collision.gameObject.GetComponent<CoOpSnakeController>().SnakeAteFood();
            Destroy(gameObject);
        }
    }
}