using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        Sheild,
        ScoreBoost
    }
    public PowerUpType powerUpType;
    public int powerDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SnakeHead"))
        {
            ActivatePowerUp(collision.gameObject);
        }
    }

    private void ActivatePowerUp(GameObject snake)
    {
        SnakeController snakeController = snake.GetComponent<SnakeController>();
        if( snakeController != null)
        {
            switch (powerUpType)
            {
                case PowerUpType.Sheild:
                    PowerUpManager.Instance.ActivateShield(snakeController, powerDuration);
                    break;
                case PowerUpType.ScoreBoost:
                    PowerUpManager.Instance.ActivateScoreBooster(snakeController, powerDuration);
                    break;
            }
        }
        Destroy(gameObject);
    }


}


