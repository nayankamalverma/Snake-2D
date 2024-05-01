using UnityEngine;

public class GameAssets : MonoBehaviour
{

    public static GameAssets Instance;

    private void Awake() {
        Instance = this;
    }

    public Sprite snakeHeadSprite;
    public Sprite snakeBodySprite;
    public Sprite foodSprite;
    public GameObject foodPrefab;
    public GameObject SnakeBodyPrefab;

}
