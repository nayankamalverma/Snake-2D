using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] public GameObject shield;
    private static PowerUpManager instance;
    public static PowerUpManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

     public void ActivateShield(SnakeController snake, int duration){
        shield.SetActive(true);
        snake.shield = true;
        StartCoroutine(ShieldEffectDurationCoroutine(snake, duration));
    }

    public void ActivateScoreBooster(SnakeController snake, int duration)
    {
        snake.scorePoint = 20;
        StartCoroutine(ScoreBoosterEffectDurationCoroutine(snake, duration));
    }

    private System.Collections.IEnumerator ShieldEffectDurationCoroutine(SnakeController snake, int duration)
    {
        
        yield return new WaitForSeconds(duration);
        snake.shield = false;
        shield.SetActive(false);
        
    }
    private  System.Collections.IEnumerator ScoreBoosterEffectDurationCoroutine(SnakeController snake, int duration)
    {
        yield return new WaitForSeconds(duration);
        snake.scorePoint = 10;
    }
}
