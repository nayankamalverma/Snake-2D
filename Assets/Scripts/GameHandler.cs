using UnityEngine;

public class GameHandler : MonoBehaviour {

    [SerializeField]
    private Snake snake;
    private LevelGrid levelGrid;
    private int maxBoundX;
    private int maxBoundY;
    [SerializeField]
    private GameObject grid;
    [SerializeField]
    private GameObject camera;

    private void Awake()
    {
        maxBoundX = (int)grid.transform.localScale.x;
        maxBoundY = (int)grid.transform.localScale.y;
        grid.transform.position = new Vector3(maxBoundX/2, maxBoundY/2);
        camera.transform.position = new Vector3(maxBoundX/2,maxBoundY/2,-10f);
        
    }
    private void Start() {
        levelGrid = new LevelGrid(maxBoundX, maxBoundY);
        
        snake.Setup(levelGrid, maxBoundX, maxBoundY);
        levelGrid.Setup(snake);
    }

}
