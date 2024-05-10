using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;
    public static GameAssets Instance {  get { return instance; } }

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }

    public GameObject FoodPrefab;
    public GameObject SnakeBodyPrefab;
    public GameObject RedSnakeBodyPerfab;
    public GameObject BlueSnakeBodyPerfab;

}
