using UnityEngine;

public class GameAssets : MonoBehaviour
{

    public static GameAssets Instance;

    private void Awake() {
        Instance = this;
    }

    public Sprite snakeHeadSprite;
    public Sprite snakeBodySprite;
    public Sprite food;

}
