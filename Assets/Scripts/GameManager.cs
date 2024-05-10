using UnityEngine;

public class GameManager : MonoBehaviour
{

    /*
     add game pause and gameover menu 
     */

    [SerializeField] private SnakeController snake;
    private FoodController foodController;
    [SerializeField] private GameObject grid;
    [SerializeField] private new GameObject camera;

    //ui and gameState
    [SerializeField] private GameObject gamePauseMenu;
    [SerializeField] private GameObject gameOverMenu;

    public int maxBoundX;
    public int maxBoundY;

    //singleton
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private void Awake()
    {
        //singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        maxBoundX = (int)grid.transform.localScale.x;
        maxBoundY = (int)grid.transform.localScale.y;
        grid.transform.position = new Vector3(maxBoundX / 2, maxBoundY / 2);
        camera.transform.position = new Vector3(maxBoundX / 2, maxBoundY / 2 + 1, -10f);

    }
    private void Start()
    {
        foodController = new FoodController(maxBoundX, maxBoundY);
        snake.Setup(foodController, maxBoundX, maxBoundY);
        foodController.Setup(snake);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseGame();
    }

    public void PauseGame()
    {
        gamePauseMenu.SetActive(true);
        snake.enabled = false;
    }
    public void ResumeGame()
    {
        snake.enabled = true;
    }

    public void GameOver()
    {
       if(!snake.shield){ 
            snake.shield = false;
            snake.enabled = false;
            gameOverMenu.SetActive(true);
        }
    }
}
