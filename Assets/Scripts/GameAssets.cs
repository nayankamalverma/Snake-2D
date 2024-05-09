using UnityEngine;

public class GameAssets : MonoBehaviour
{

    public static GameAssets Instance;

    private void Awake() {
        Instance = this;
    }

    public Sprite SnakeHeadSprite;
    public Sprite SnakeBodySprite;
    public Sprite FoodSprite;
    public GameObject FoodPrefab;
    public GameObject SnakeBodyPrefab;

}
