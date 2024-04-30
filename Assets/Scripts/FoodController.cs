using UnityEngine;

public class FoodController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("apple");
    }
}
