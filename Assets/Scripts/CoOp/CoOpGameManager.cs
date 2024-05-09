using TMPro;
using UnityEngine;

public class CoOpGameManager : MonoBehaviour
{
    [SerializeField] private CoOpSnakeController redSnake;
    [SerializeField] private CoOpSnakeController blueSnake;
    private CoOpFoodController foodController;
    [SerializeField] private GameObject grid;
    [SerializeField] private new GameObject camera;

    //ui and gameState
    [SerializeField] private GameObject gamePauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI playerWonText; 

    private int maxBoundX;
    private int maxBoundY;

    //singleton
    private static CoOpGameManager instance;
    public static CoOpGameManager Instance { get { return instance; } }
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

        foodController = new CoOpFoodController(maxBoundX, maxBoundY);
        redSnake.Setup(foodController, maxBoundX, maxBoundY);
        blueSnake.Setup(foodController, maxBoundX, maxBoundY);
        foodController.Setup(redSnake,blueSnake);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseGame();
    }

    public void PauseGame()
    {
        gamePauseMenu.SetActive(true);
        redSnake.enabled = false;
        blueSnake.enabled=false;
    }
    public void ResumeGame()
    {
        redSnake.enabled = true;
        blueSnake.enabled=true;
    }

    public void GameOver(string objectTag)
    {
        redSnake.enabled = false;
        blueSnake.enabled=false;
        gameOverMenu.SetActive(true);
        playerWonText.text = (objectTag == "BlueSnake")? "Red Snake Won!": "Blue Snake won";
    }
}
